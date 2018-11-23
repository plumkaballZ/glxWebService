using GlbXWebService._logics;
using GlbXWebService._models;
using GlbXWebService._repo;
using GlbXWebService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService._services
{
    public class xOrderService
    {
        private PakkelabelsApiClient _pakkeLabbelsApiClient;
        public PakkelabelsApiClient PakkeLabelsApiClient
        {
            get
            {
                if (_pakkeLabbelsApiClient == null) _pakkeLabbelsApiClient = new PakkelabelsApiClient();
                return _pakkeLabbelsApiClient;
            }
        }

        private xOrderRepo _xOrderRepo;
        private xUserRepo _xUserRepo;

        public xOrderService()
        {
            _xOrderRepo = new xOrderRepo();
            _xUserRepo = new xUserRepo();
        }


        public bool HandleUpdateOrder(GlxUserRequest req)
        {
            if (req.Order != null)
            {
                var cmd = req.Order.special_instructions;

                if (cmd == "updatePayment")
                    SetPaymentDoneAndCreateShipment(req.Order);

                if (cmd == "updateShipment")
                    SetShipmentSent(req.Order);

                if (cmd == "addLineItem")
                    CreateOrderLinesOnOrder(req.Order);

                if (cmd == "deleteLineItem")
                    DeleteOrderLineFromOrder(req.Order);

                return true;
            }

            return false;
        }


        private bool DeleteOrderLineFromOrder(xOrder order)
        {
            foreach (var orderLine in order.line_items)
            {
                if (orderLine.delStr == "true")
                    _xOrderRepo.DeleteOrderLine(order.id, orderLine);
            }

            return true;
        }
        private bool CreateOrderLinesOnOrder(xOrder order)
        {
            foreach (var orderLine in order.line_items)
                _xOrderRepo.CreateOrderLine(order.id, orderLine);

            return true;
        }
        private bool SetShipmentSent(xOrder order)
        {
            return _xOrderRepo.SetShipmentSent(order.id, order.ship_address.uid);
        }
        private bool SetPaymentDoneAndCreateShipment(xOrder order)
        {
            try
            {
                _xOrderRepo.SetPaymentDone(order.id, order.ship_address.uid, order.ship_total);

                var str = PakkeLabelsApiClient.CreateImportedShipment(new xAddress()
                {
                    firstname = order.ship_address.firstname,
                    address1 = order.ship_address.address1,
                    countryId = order.ship_address.countryId,
                    phone = order.ship_address.phone,
                    zipcode = order.ship_address.zipcode,
                    city = order.ship_address.city
                },
                order.ship_address.email,
                order.id,
                order.deliveryCode,
                order.shippingId);

            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }
    }
}

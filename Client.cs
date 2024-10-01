using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class Client
    {
        private Packaging _packaging;
        private DeliveryDocument _deliveryDocument;
        public Client(PacknDelvFactory factory)
        {
            _packaging = factory.CreatePackaging();
            _deliveryDocument = factory.CreateDeliveryDocument();
        }
        public Packaging ClientPackaging
        {
            get { return _packaging; }
        }
        public DeliveryDocument ClientDocument
        {
            get { return _deliveryDocument; }
        }

    }
}

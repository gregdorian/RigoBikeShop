
using System.Data;

using RigoBikeshop.Domain.Entities;
using RigoBikeshop.Infraestructure.Data;

namespace Domain.core
{
    public static class Venta
    {


        public static Producto Prod { get; private set; }

        //ProductoPersistence prod = new ProductoPersistence();

        //prod GetIdProducto(id);

        public static List<DataRow> ConsultarFacturasId(int IdFacturaEncabezado)
        {
           
            DataTable dtConsultaFactura;
            dtConsultaFactura = FacturaPersistence.GetIdFactura(IdFacturaEncabezado);

            List<DataRow> lstClientes = dtConsultaFactura.AsEnumerable().ToList();

            return lstClientes;
        }


        //public OrderLine AddNewOrderLine(Guid productId, int amount, decimal unitPrice, decimal discount)
        //{
        //    //check precondition
        //    if (amount <= 0
        //       ||
        //        productId == Guid.Empty)
        //    {
        //        throw new ArgumentException(messages.GetStringResource(LocalizationKeys.Domain.exception_InvalidDataForOrderLine));
        //    }

        //    //check discount values
        //    if (discount < 0)
        //        discount = 0;


        //    if (discount > 100)
        //        discount = 100;

        //    //create new order line
        //    var newOrderLine = new OrderLine()
        //    {
        //        OrderId = this.Id,
        //        ProductId = productId,
        //        Amount = amount,
        //        Discount = discount,
        //        UnitPrice = unitPrice
        //    };
        //    //set identity
        //    newOrderLine.GenerateNewIdentity();

        //    //add order line
        //    this.OrderLines.Add(newOrderLine);

        //    //return added orderline
        //    return newOrderLine;
        //}
       
        public static bool RegistrarFacturaVenta(FacturaEncabezado oFacturaVta)
        {
            try
            {
               
                FacturaPersistence.CreateFactura(oFacturaVta);
                return true;
            }
            catch (Exception ex )
            {
                return false;
                throw ex;
            }
            
        }



    }
}

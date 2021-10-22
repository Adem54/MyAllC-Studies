using MusteriYonetimSistUygulamasi.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygulamasi.Adapters
{
    public class MernisServiceAdapter : ICustomerCheckService
    {
        public bool CheckIfRealPerson(Customer customer)
        {
            //KENDIMIZE BIR ADAPTOR YAPTIK BURDA BUDA CUSTOMERCHECKSERVICE I IMPLEMENT ETTI O DA BIR CUSTOMERCHECKSERVICE
            //YARIN OBURGUN TEST ORTAMNDA CALISILACAGI ZAMAN DIREK BU KULLANILABILIR
            // MernisServiceReferance.KPSPublicSoapClient client = new MernisServiceReferance.KPSPublicSoapClient();
            //return client.TCKimlikDogrula(Convert.ToInt64(customer.NationalityId,customer.FirstName.ToUpper,
            //customer.LastName.ToUpper, customer.DateOfBirth.Year)

        };

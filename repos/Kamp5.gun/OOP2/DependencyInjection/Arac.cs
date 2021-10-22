using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    //SETTER INJECTION
    //Setter Injection(Setter Based Dependency Injection) yöntemi ile DI’yı uygulamak istiyorsanız eğer sadece
    //“Arac” sınıfında(yani projenizde DI’yı uyguladığınız sınıfta) aşağıdaki değişikliği yapmanız yeterlidir.
    //Arac sinifinda tipi interface olan yeni bir property yazariz
    //Sonra o interface degiskeni uzerinden Kullan methodu icinde _tasit degiskeni uzerinden interface icindeki imzalari cagiririz

    class Arac
    {
        public ITasit _tasit { get; set; }
        public void Kullan()
        {
            _tasit.GazVer();
            _tasit.SagaSinyal();
            _tasit.FrenYap();
            _tasit.SolaSinyal();
        } 
    }
}

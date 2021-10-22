using System;
using System.Collections.Generic;

namespace Actions
{
    class Program
    {
        static void Main(string[] args)
        {
           
            try
            {
                Find();
            }
            catch (RecordNotFoundException exception)
            {

                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {

            }
            //Her method icin ayri ayri try-catch yazmaktansa onun yerine alttaki handleException i yazip
            //daha temiz bir goruntu elde etmis oluruz....
            Console.WriteLine("--------------------------------------");
           


            //DELEGATE ACTION ILE CALISMAK
            //Action dedigimiz bir operasyona veye methoda karsilik gelir method ve void olanlari calistirmak
            //uzere tasarlanmis bir mimaridir
            //Action bir delege tipidir ve bir deger return etmez o yuzden sadece void lere hastir
            //Biz exception yonetiminde try-catch ile yonetiyorduk ama her seferinde try-catch yazmak
            //yorucu olabilir onun icin merkezi bir exeption ortami olusturabiliriz

            HandleException(() =>//Parametresiz bir methoda delege edecegimizi soyluyoruz burda
            {
                Find();//Action icin gonderilen kod blogudur ve HandleException da invoke diye calistirilir
            });
            //Delegate Action ile biz her seferinde try-catch yazmaktan kurtulmus oluyoruz
            //Delegate teki amac surekli calistirdigimiz kodlar degilde mesela bir veritabanina bir kayit
            //yapiyoruz ve arkasindan bir mesaj vs bir method calissin isiyoruz iste burda da delegate
            //kullanabiliriz

            Console.ReadLine();
        }


        //Boyle bir meethod yazariz ve methoda parametre olarak action gondeririz
        //Bir tane merkezi bir try catch yaziyoruz ve her seferinde try icinde hangi method gonderirsek
        //try icinde o calisacak yani yukarda HandleException 
        //Yazdigimiz HandleException merkezi sabit kodumuzdur biz burda Action pozisyonunda olmasini iste
        //digimiz methodu yukari gider ayni Find methodu gibi parametresiz void olan bir method olmali
        //ONu HandleException icinde bir suslu parantez acip orda calistiririz ve bu sekilde action pozisyonda
        //artik Find() methodu gelmis olur yani Action,action i parametrede kullanrak Find methodunu parametreye
        //vermis oluyoruz  ve invoke ile calistirmis oluyoruz
        private static void HandleException(Action action)//Sana bir kod blogu gonderecegim onu benim icin 
            //calistir demektir bu
            //Bu kod blogudur yani methodun iceriigidir
        {
            try
            {
                action.Invoke();//Action yerine verilen methodu invoke et yani calistir
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
        }
        //Ayni yontemle transaction yonetitmi,loglama islemlerini ,validation

        private static void Find()
        {
            List<string> students = new List<string> { "Engin", "Derin", "Salih" };
            if (!students.Contains("Ahmet"))
            {
                throw new RecordNotFoundException("Record Not Found");
            }
            else
            {
                Console.WriteLine("Record Found");
            }

        }
    
}
    [SerializableAttribute]
    public class RecordNotFoundException : Exception
    {
        private string _message;
        public RecordNotFoundException(string message)
        {
            _message = message;
        }

       

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

    }
}
//Delegeta ler kendi icerisinde fonksiyon tutabuliyor ve onlari istedigi zaman cagirabiliyor
//Icerisine 5-10 tane fonksiyon atadigimiz zaman ve onu cagirdigimiz zaman onlar hizli birsekilde geleceklerdir
using System;

namespace ConstructorsAdvance
{
 public class Program
    {
        static void Main(string[] args)
        {
            //Biz asagidaki class larimiza veri atamalarini getter uzerinden yaptik yani constructor
            //uzerinden yaptik ve bu sekilde donecek veri tiplerini kontrol altina aldik!!!!!
           
            Student student1 = new Student() {StudentId=1, FirstName = "Ahmet", LastName = "Leylek" };
            //Burda biz sonradan veri olarak ne girdi isek default ta oldugu gibi onlari aliriz

            Student student2 = new Student(11) { FirstName = "Burhan", LastName = "Sergem" };
            //Burda ise class imizin bir baska versiyonunda sadece 1 tane id parametresi verdik class a
            //Suraya dikkat!! biz id yi direk verdik ve student2.StudentId ile biz class parantezine 
            //instance olustururken ne girdi isek onu aliriz....
            Student student3 = new Student(111, "Ceyda") { LastName = "Kara" };
            //student3.StudentId ve student3.FirstName biz class parametresine ne verdi isek onlari aliriz
            //Cunku biz bu ayarlamayi constructor da yaptik ve biz ne girersek onu vermesini istedik

            Student student4 = new Student(1111, "Dogan", "Yesil");
            //Dogrudan tum propertieslerin karsiligini classta vermis olduk

            Console.WriteLine("Student class inin 4.versiyonu");
            Console.WriteLine(student4.FirstName+"  | "+ student4.LastName);



           

            Console.ReadLine();
        }
    }


    //Bir tane property class i olusturalim ve bircok farkli turden veri olusturalim
   public class Student
    {

        public Student()//Biz eger default olan halini buraya yazmasak normalde hic constructor yazilma
            //digi zaman default olarak calisan constructor parametreli yeni constructor lar yazarsak
            //default constructor ezilmis olur ve calismaz ondan dolayi biz arka tarafta default olarak 
            //calisan constructorun default halini buraya da yazariz ki o da ezilmis olmasin!!!
        {

        }

        //Yaptigimiz islemin adi overloading ayni methodun farkli parametrelerle farkli versiyonlarda
        //olusturulmasidir overloading
        //Class imizii new lerken onun ayri ayri versiyonlarini yapiyoruz burda!!
      
        public Student(int studentId)
        {
            StudentId = studentId;
        }

        public Student(int studentId, string firstName)
        {
            StudentId = studentId;
            FirstName = firstName;
        }

        //Biz neden properties lere constructor icerisindeki parametrelere atamasini yapariz 
        //Cunku bizim demekki soyle bir amacimiz var biz class larimizdan instance olustururken dogrudan parametreye
        //verilerle gelecegiz ve o veriler zaten bizde var ve biz o verileri almak istiyoruz iste o verileri almanin yolu
        //Onlari propertieslere atamaktir ki sen olusturdugun bir instance uzerinden gidipde mesela
        //student4.StudentId veya student.FirstName deyince sana o sen class parametresine hangi Id ve FirstName girdi isen
        //onu verir sana ondan dolayi zaten sen bu atamayi yapmazsan anlamsiz olur!!Constructor bu yuzden kullanilir!!!!
        public Student(int studentId,string firstName, string lastName)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;

        }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

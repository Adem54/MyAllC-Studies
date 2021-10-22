
--SELECT  Select * from Customers=>customers datasini tamamen sec getir demektir
-- * in uzerine maus imleci ile gelirsek zaten hangi tablolari getirecegini gosterir bize
 --1)
 --  Select * from Customers
--Select datayi sec demek, select ten sonra gelen kisim kolonlardir hangi kolonlari sececegimizi belirtiriz
-- * demek tum kolonlari sec demektir
--Ilerde ogrenecegimiz view da da bu sekilde calisir
--Yazidigim sorgu sonucu gelen veriyo gorebilmek icin ustte sol da kalan play tusu ile yapabiliriz
  --2)
  --Select ContactName,City,Country from Customers
--Customers tablosundan ContactName,City ve 'Country kolonlari sec getir demis olduk burda da
--Biz Select ile bu sekilde bazi kolonlari secip sorgula getir dedigimizde bu bellekte fake bir tablo olusturuyor 
--ve bize o tabloyu gosteriyor. Ayni C# daki Liste gibi bir liste olusturuyor
--Sunu iyi bilelim bizim sorgu yaparak su an gelen veriler de bir tablodur yani biz ilerleyen zamanlarda
--busekilde bazi kolonlarini cagirdigimiz veritabanindan gelen tabloy a da select yapmak isteyebiliriz
--ki bu gercek hayatta cok yapiliyor bir select yazip bazi kolonlari getirip gelen de bir tablodur ve onu
--baska bir tablo ile join edebiliyoruz
--ONEMLI!!!!!UNUTMA!!SELECT ILE SORGU YAPIP CAGIRDIGIMIZ BAZI KOLONLAR DA BIR TABLODUR BIZIM ICIN DOLAYSI ILE
--BIZ O TABLONUN UZERINDE DE QUERY,YANI SORGU , SELECT YAPABILIRZ , BASKA BIR TABLO ILE JOIN YAPABILIRZ
--Select yaparak cagirdigimiz karsimiza gelen tablonun kolon isimlerine istersek alyas verebiliriz yani yeni isim
--verebiliriz
--3)
--Select ContactName IletisimAdi, City Sehir, Country Ulke from Customers
--ONEMLI!!!!
--Biz su an Sql server da calisiyoruz ama yazdigimiz kod Oracle,MySql de de calisir bunlar ansi standartlaridir

--WHERE KOSULU ILE FILTRELEME  YAPMA
--4)
--Select * from Customers where City='London'
--Metinler Ansi standartlarinda tek tirnakla yazilir cift tirnak yazarsak veriyi alaamayiz
--Tum customers kolonlarini sec yani tum kolondaki bilgileri getirecek ve where sarti ie City London olanlari sec
--Sehri Londro olanlari tum kolonlari ile getir demis oluruz burda
--Ansi standartlarina gore buyuk kucuk harf duyarliligi yoktur yani biz ister buyuk harfle istersek kucuk harfle
--query kodlarimizi yazabiliriz demektir bu
--5
--SELECT * From PRODUCTS where CategoryId=1
--Biz bir e-ticaret sitesinde sol sidebar da bir urun kategorisi secip tiklagimizda iste bizim ustteki kodumuz gibi 
--bir kod calisir ve bize sectigimiz kategorideki urunleri getirir
--6
--Select * from Products where CategoryId=1 or CategoryId=3
--Bu kodda mesela biz iki tane kategori biren seciyoruz ve her ikisini de getir diyoruz
--7
--Select * from Products where CategoryId=3 and UnitPrice>10.00
--Hem kategorisi 3 olsun hem de fiyati 10 dan buyuk olsun dersek o zaman da bize sectigimiz bir urununun
--mesela bilgisayar kategorisinden ornegin fiyati 2000 ustu olanlari gormek isterken iste bu kod calisiyor
--8
--Select * from Products where CategoryId=1 and UnitPrice<>18.00
-- Kategorisi 1 olan ve unitprice i 18 den farkli olanlari getir dedik burdada

--FILTRELEME YAPMA
--E-ticaret sitlerinde biz alfabeya gore, fiyatin azalan veya artana gore filtrelemeler yapariz simdi buna bakalim
--ORDER BY ILE SIRALAMA YAPMAK
 --9
 --  Select * from Products order by ProductName
--Urun ismine gore yani A-dan Z ye dogru siraladi
 --10
 --Select* from Products order by CategoryId
--KategoryId yi kucukten buyuge dogru siraladi
 --11
 --Select * from Products order by CategoryId,ProductName
--Burda once CategoryId ye gore kucukten buyuge siralar sonra da her kategory yi yani mesela diyelim ki kagetory
--kagetoryId si 1 olan 10 tan urunu kendi icinde alfabe sirasina gore siralar, iste diger tum kategorideki 
--elemanlarda ayni skildedir
--12
 -- Select* from Products order by UnitPrice asc --asc yi vermesek de olur
  --asc ascending -ingilizcede artan demek-fiyat azalan da "desc" dir 
  --desc de ingilizcede descending azalan demektir
  --Fiyata gore azalandan artana dogru siralmasi ile getiriyor karsimiza bizim bir e-ticaret sitesinde fiyati 
  --filtrelemesi ile fiyati kucukten buyuge getirebilmemizin kodsal karsiligi iste budur
  --Azalan yaparken desc vermek zorundayiz ama artan yaparken asc yi vermesek de o artan sekilde siraliiyr
  --13
  --select * from Products order by  UnitPrice desc
  --En yuksek fiyattan en dusuk fiyata dorgu gelir
  --14
  --select * from Products where CategoryId=1 order by UnitPrice desc
  --Once CategoryId yi filtrele sonra da UnitPrice yani fiyata gore sirala demektir
  --Tum e-ticaret sitelerinde yaptigimiz islem bu aslinda, once kategori seceriz sonra da o kategoryi fiyata gore
  --fiyata gore siralariz.......
  --15
  --Select count(*) from Products 
  --sectigimiz tablo da veya kolonlarda toplam kac urun var kac satir var onu hesaplar
  --Bazen e-ticaret sitelerinde biz en altta toplam su kadar urunumuz vardir diye bir sayi goruruz iste bu sekilde
  --hesaplanir
  --Select count(*) ,ProductName from Products--Bu kullanim yanlistir hem tamamini sec diyoruz hem de gelip Product
  --ProductName i sec diyoruz kolon olarak
  --16
  --Select count(ProductName) from Products --bu da ProductName i say demis oluyoruz..
  --17
  --Select count(*) from Products where CategoryId=2
  --Kategori id si 2 olanlarin sayisini bana getir demektir
  --Ayas kullanarak da bu sorguyu yapabiliriz
  --18
  --Select count(*) Adet from Products where CategoryId=2
  --Tekrar hatirlayalim bizim yaptigimiz sorgularda karsimiza gelen veriler de bir tablodur

  --Biz Select ile count dedigimiz zaman tum kolonlari say deyip sonra yanina bir kolon yazarsak yanlis olur
  --Arka tarafta dizi mantigi  ile calisip verileri getiriyor bize,liste mantigi ile calisiyor
  --SQL HERZAMAN SEKTORDE DEGERLIDIR..PERFORMANSLI SQL YAZMAK..
  --Sql i iyi bilmek ve performansli sql yazmak sektorde herzaman kiymetlidir

  --Elimizde yeni bir senaryomuz var yonetim dedi ki hangi kategori de elimizde kac farkli urunumuz var diye sordu
  --Tum kagerileri ayri ayri kacar tane urunumuz var onu gormek istiyoruz..
  --Kategorilerin id lerini ve yanlarinda kacar tane urun var her kategoriden onu istiyoruz
  --ONEMLI!!!!!BUNA DIKKAT ET..
  --Tum tabloyu getir dedigimiz zaman bizim tum tablodaki her bir satirimiz yani her bir urun C# da bir class tir
  -- select * from Products group by CategoryId =>Bu herhangi bir veri getirmeyecektir cunku group by kullandi
  --gimiz zaman bu datami categoryId ye gore grupla demektir dolayisi ile burda * olmamalidir.
  --Group by ile calisirken select ettiginiz kolon sadece ve sadece group by dan sonra yazdiginiz alan olabilir 
  --ve kumulatif datalar olabilir count(*) gibi dolayisi ile biz categoryId ye gore gruplayalim simdi
  --19
  --select CategoryId from Products group by CategoryId
  
  --Datamizi tamamen ve tamamen group by ifadesinde belirtilen e gore verdik
  --Bu demektir ki categorilerin icine bak ve tum kategorileri tekrar etmeyecek sekilde bana listele demektir
  --Group by yaptigin zaman aslinda her bir grup icin arka planda tablo olusturuluyor mus gibi dusunebilirsin
  --Burasi kategoryId leri benzersiz bir sekilde getir demektir ama buraya biz eger count(*) eklersek  o zaman
  --da demis oluyorz ki tum satirlar icinde categor ylere gore kacar adet varsa her katagoriden  onun sayisini getir
  --demektir
  --20
  --select count(*) Adet from Products 
  --Burda grouop by olmadigi icin bir kere donuyor arkada ve hesaplama yapiyor
  --Ama asagidaki group by ile yapilan sorguda ise group bu old icin her bir kategori icin bir count calisir arkada
  --21
  --select CategoryId,count(*) from Products group by CategoryId
  --1 numarali kategoriden 12 adet, 2 numarali kategori den 12 adet seklinde her kategoriden kacar 
  --satir varmis onu buluruz
 --Burda yazilan count her kategori icin ayri ayri hesaplaniyor yani her bir grup elemani icin ayrica count hesap
 --laniyor
 --IKI KOLONA BIRDEN GROUP BY DA YAPABILIRZ
 --22
 --select CategoryId,SupplierId, count(*) from Products group by CategoryId,SupplierId

 --COK ONEMLI GERCEK HAYATTAN ORNEKLER
 --Bunlar Karar Destek Sistemlerinde yani KDS sistemlerinde yogun olarak kullanilmaktadir
 --Yonetim sunu ister senden hangi kategorilerde az urunumuz varsa oralari besleyelim cunku oralarda eksik kalmisiz demektir
 --Bana urun sayisi 10 dan az olan kategorileri listele diyebilir
--Bu tarz taleplerde biz where kosulunu kumulatif dataya yazariz yani ustuste toplanmis ve gruplanmis dataya
--Bu yuzden group by larda kumulatif dataya yazilan kosul having olarak yazilir
--HAVING-- KUMULATIF DATAYA YAZILIR....
--URUN CESIDI 10 TANE DEN AZ OLAN URUN KATEGORILERININ SAYISI GETIRMEMIZ ISTENIRSE ASAGIDAKI SORGUYU YAZARIZ...
--23
--select CategoryId, count(*) from Products group by CategoryId having count(*)<10
--count() parantez icine ne alirsa onun sayisini alir, avg() bu da ortalamasini getirir, sum() toplami getirir
--HICBIRZAMAN UNUTMA HAVING KUMULATIF DATALARA YANI COUNT(*) GIBI DATALARA UYGULANIR
--PEKI ONCE WHERE ILE BIR SART VERELIM YANI WHERE ILE BIR FILTRELEME YAPALIM....
--HER ZAMAN ONCE WHERE CALISIR UNUTMAYALIMMMM
--24
--select CategoryId, count(*) from Products where UnitPrice>20 group by CategoryId having count(*)<10
--UnitPrice i 20 den buyuk olan urunleri kategoriye gore grupla onlardan da sayisi 10 tanenin altinda olanlari getir
--Once veriyi filtreler where ile daha sonra group by ile categoriye gore gruplar sonra da sayisi 10 dan az olani
--getirirr
--Biz UnitPrice>20 deyince sayilar azaldi ve kategori sayisi 10 dan kucuk olan kategori adetleri artmis oldu

--JOINLER ILE ID LER UZERINDEN TABLO BIRLESTIRME....COOOOK ONEMLI.....
--Biz veritabani tasarimi yaparken kendimizi tekrar etmemek icin tablolari iliskilendiririz
--Veritabanimizda kategorileri biz id si ile KategoriId ile tutariz ama son kullaniciya ulastiginda biz dogrudan
--kategori ide ile degil de birlestirerek getiririz yani kullaniciya kategoriId ile degil de kategoriName ile  
--getiririz iste bu birlestirme islemlerini join ile yapariz
--Yani bizim products tablomuzda sadece categoryId vardir categoryName ise categories tablomuzdadir iste biz
--hem urunumuzun ismine hem de kategorisinin ismine ulasmak iciin bu iki tabloyu birbirine baglamak zorundayim
--25--COOK ONEMLI...IYI OGREN...
--select * -- * dedigimiz icin urunle ilgili tum kolonlari getirdi
--from Products inner join Categories --from hem products hem de categories tablosundan anlamina gelir
--neye gore bir araya getirecegimiz belirtmek icin on kullaniriz on=>durumndaki,sartindaki demek
--on Products.CategoryID=Categories.CategoryID --onlar esit se onlara gore getir
--neye gore joinleyecegim neye gore birlestirecegim kosulunu on ile yazariz..
--Biz join islemi ile iki tabloyu birlestirdigimiz icin artik tablo kolonlarini dogrudan yazarak erisemeyiz
-- artik tablolarimizda kolonlara tabloIsmi . kolonIsmi yazarak erisebiliriz...
--26 SUPER IYI OGREN!..
--select Products.ProductID,Products.ProductName,Products.UnitPrice,Categories.CategoryID,Categories.CategoryName
--from Products inner join Categories on Products.CategoryId=Categories.CategoryID
--ONEMLI GERCEK HAYATTAN ORNEKLER
--Biz e-ticaret sitesinde karsimiza gelen verilere bakarak veritabaninda sadece o bilgiler var zannedebiliriz ama
--oyle degil tabiki o bilgiler birkac tane tablodan join ile birlestirilmis ve bazi kolonlari secilmistir yoksa
--veritabaninda cok daha fazla bilgiler vardir
--urun tedarikci bilgieri,urun detaylari bilgileri,
--ONCE BU SEKILDE VERILERI VERITABANINDA KULLANICIYA GOSTERECEK SEKILDE JOIN ILE BIRLESTIRIR VE ISTEDIGIMIZ KOLONLARI
--SECERIZ DAHA SONRA DA BUNLARI GIDIP C# TARAFINDA KULLANICIYA FOREACH ILE DONDERIP LISTELERIZ...
--GORSELLIKDE SAGLAYARAK ANGULAR,REACT VS ILE KULLANICININ ONUNE GETIRIRIZ....

--C# da DTO-data transformation object
--Biz product ,customer, category icin ayri class bankadaki kredi icin ayri class vs yapiyorduk birde boyle
-- joinli yapilar icin class yapacagiz cunku biz bunu liste haline getirecegiz iste buna Data transformation object
--diyoruz

--JOIN ILE BIRLESTIRDIGIMIZ TABLOLARA WHERE ILE FILTRELEME YAPMA
--27 SUPER COK IYI OGREN!!..
--select Products.ProductID,products.ProductName,Categories.CategoryID,categories.CategoryName,Products.UnitPrice
--from Products inner join Categories on Products.CategoryId=Categories.CategoryID 
--where Products.UnitPrice > 10
--Fiyati 10 dan buyuk urunleri kategoori ismi ile beraber getiren sorgudur 
--IKI FARKLI JOIN VARDIR 
-- INNER JOIN SADECE IKI TABLODA DA ESLESENLERI BIRARAYA GETIRIR ESLESMEYEN DATA VARSA ONU GETIRMEZ...
--JOINLERDE HERZAMAN * LA BASLARIZ...
--28
-- select * from Products p inner join [Order Details] od on P.ProductId=Od.OrderId
--Products icin alyas olarak p, OrderDetails tablosu icin kisaltma alyas olarak od yaziyoruz
--Order Details siparis detaylari tablosu
--[Order Details] boyle yazaric cunku bosluk isimlendirme standartlarinda dogru degildir dolayisi ile 
--bunu sanki iki farkli kod mus gibi algilamasin diye SQL de biz onu koseli parantez icine aliriz 
-- [Order Details] Order ile Details arasinda bosluk old. icin koseli parantez kullanilmasinin tek sebebi
-- bunlari birlesik olarak algilasin farkli algilamasin diye
--inner JOIN ICIN ONEMLI BILGI...
--Iki tabloyu join edecegimiz zaman iki tablodaki ortak kolonu bulmamiz gerekiyor
--INNER JOIN SADECE ESLESEN KAYITLARI GETIRIR

--ONEMLI!!GERCEK HAYATTAN ORNEKLER
--YONETIM BIZE DEDI KI HIC SATIS YAPAMADIGIMIZ URUNLER NELERDIR
--CUNKU O URUNLERI KAMPANYA YAPIP , O URUNLERI INSANLARI ALMAYA TESVIK EDIP URUNLERI ELDEN CIKARMAK ICIN
--INNER JOIN IKI TABLODA DA ESLESEN BIR VERI VARSA BIRLESTIRIR BURDA ISIMIZI GORMEZ...
--LEFT JOIN!!!!!!!!!!!!!
-- LEFT JOIN-SOLDA OLUP DA SAGDA OLMAYANLARI DA  GETIR 
--PRODUCTS TA VAR AMA ORDERDETAILS DE YOK YANI URUNLER DE URUN OLARAK VAR AMA ORDERDETAILS TABLOSUNDA YOK YANI
--URUN ELDE VAR AMA SIPARS YOK SIPARIS VEREN YOK YANI HIC SATIS YAPAMADIGIMIZ URUNLER I BU SEKILDE GETIRIRIZ...
-- 29--COOOKKK ONEMLIII
--select * from Products p left join [Order Details] od on p.ProductID=od.ProductID
--Urunlerin hepsi de geldi bu su anlama geliyor Products ta olup da OrderDetails de olmayan yok demektir
--Hem inner join olanlari hem de sol da olmayanlari getiriyor bu sekilde

--ONEMLI--MUSTERI BILGISI ORDER TABLOSUNDA OLUR  CUNKU SIPARISIN BIR MUSTERISI OLUR
--PRODUCT BILGISI ORDERDETAILS DE OLUR

--INNER JOIN BUNLAR  ESLESENLER
--30-
--select * from Customers c inner join Orders o on c.CustomerID=o.CustomerID
--Biraz cok gelebilir cunku her sipariste birden fazl urun vardir.Bunlar eslesenler inner join
--830 kisi geliyor inner join yapinca
--LEFT JOIN -HEM CAKISANLAR HEM DE MUSTERI DE OLUP AMA SIPARISTE OLMAYANLAR YANI SIPARISI OLMAYAN MUSTERILER
--31
--select * from Customers c left join Orders o on c.CustomerID=o.CustomerID where o.CustomerID
--BIZ BU TABLOYU WHERE ILE FILTRELER VE NULL LARI GETIRIRIZ
--32
--select * from Customers c left join Orders o on c.CustomerID=o.CustomerID where o.CustomerID is null
--ONEMLI!!! GERCEK HAYAT SENARYOSU
--BIZE MUSTERI OLARAK KAYDOLMUS AMA BIZDEN URUN ALMAMIS LISTESINI BANA GETIR BEN ONLARA KAMPANYA UYGULAYACAGIM
-- BIZDEN URUN ALMAMIS MUSTERILERI URUN ALMAYA TESVIK ETMEK ICIN ONLARA OZEL KAMPANYA UYGULAYACAGIM VE ONLARI
--AKTIF MUSTERI HALINE GETIRMEK ISTIYORUM
--BAZEN E-TICARET SITESINE KAYIT OLURSANIZ DER KI SANA OZEL ILK SIPARISINDE 20% INDIRIM
--SANA OZEL OLAN SENI BULURKEN BU SORGUYU CALISTIRARAK BULUYOR
--ARKA PLANDA KAMPANYA YONETIM SAYFALARI OLUR E-TICARET SITELERINDE, BIZIM GOREMEDIGIMIZ KAMPANYAYI GIRER BU BILGI
-- YI SECER BASAR DUGMEYE BU MUSTERILERE GONDERIR KAMPANYA BILGISINI 
--solda olmayip sagda olmayanlari gormek icin sagda olmayanlar null olarak gelir ve null lar is ile gosterilir
--IS NULL-OLARAK GOSTERILIR
--BIR VER BIRYERDE YOKSA O NULL DUR VE YAZARKEN =NULL OLMAZ IS NULL OLUR!!!
--JOIN DE KOSULLARI BIZ IKI TABLODA DA BULUNAN PRIMARY KEYE UYGULARIZ AKSI TAKDIRDE DIGER VERILER 
--DE BAZEN NULL OLABILIR O ZAMAN ZATEN ESLESTIREMEYIZ...

--RIGHT JOIN----!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
--SAGDAKI TABLODA OLUP SOLDAKI TABLODA OLMAYANLARI DA GETIR.....
--DOLAYISI ILE BIZ SAGDA OLUP SOLDA OLMAYANLAR DIYE QUERY YAPARKEN LEFT JOIN DE YAZDIGIMIZ TABLOLARIN YERINI
--DEGISTIREREK AYNI VERILERE RIGTH JOIN ILE DE ULASABILIRIZ
--select * from Customers c right join Orders o on c.CustomerID=o.CustomerID
-- bu customers tablosu ile orders tablosu icindeki ortak customerid leri getirir bize ve ayrica sagda olup da
-- solda olmayanlari da getirir ama sagda olup da solda olmayan diye birsey olmayacagi icin ekstra cok da birsey
--getirmeyecektir aslinda
--33
--select * from Customers c right join Orders o on c.CustomerID=o.CustomerID where c.CustomerID is null
--Bu sorgu hicbirsey getirmez cunku siparist e olup musteri de olmayan diye birsey yoktur siparis varsa musteride
--vardir cunku
--34
--select * from Orders o right join Customers c on o.CustomerID=c.CustomerID where o.CustomerID is null
--BURDA LEFT JOIN ILE YAPTIGIMIZIN AYNISINI RIGHT JOIN ILE SORGUDAKI TABLO YERLERINI DEGISTIREREK ELDE ETTIK
--NORMALDE RIGHT JOIN DE LEFT JOIN DE KULLANILABILIR AMA ANA TABLO ONCE YAZILDIGI ICIN GENELLIKLE ONDAN DOLAYI
--DAHA COK LEFT JOIN TERCIH EDILIR!!!!!!

-- IKIDEN FAZLA TABLOYU JOIN ETMEK ICIN NE YAPARSIN!!!!!
select * from Products p inner join [Order Details] od on p.ProductID=od.ProductID 
inner join Orders o on od.OrderID=o.OrderID

--	ikiden fazla tablo yu birlestirmek istersek de ilk 2 tablonun sorgusu bitince inner join tekrar bir tablo daha
--ekleriz..






































































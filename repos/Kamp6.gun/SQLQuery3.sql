
--HOMEWORK!!!!
--SQL bir veri tabanindaki bir tablomuzda :
--HerBir SAtir=Bir class tir ve bir urun un tamamini veya bir musterinin tum bilgilerini
--temsil eder yani bir kayittir her bir satir bir kayiti temsil eder
--Her bir sutun ise yani kolon ise bir o urunun bir ozelligidir
--Tablolar cogul isimle isimlendirilir Customers, Orders gibi
--Sql de case sensetive lik yoktur yani buyuk harf kucuk harf hassasiyeti yoktur

--1)
 -- Select * from Customers 
-- * HEPSINI SEC DEMEKTIR

--Some of The Most Important SQL Commands
--SELECT - extracts data from a database
--UPDATE - updates data in a database
--DELETE - deletes data from a database
--INSERT INTO - inserts new data into a database
--CREATE DATABASE - creates a new database
--ALTER DATABASE - modifies a database
--CREATE TABLE - creates a new table
--ALTER TABLE - modifies a table
--DROP TABLE - deletes a table
--CREATE INDEX - creates an index (search key)
--DROP INDEX - deletes an index


--SELECT Syntax---

--SELECT column1, column2, ... FROM table_name;

--SELECT * FROM table_name;
--2)
--SELECT CompanyName, ContactName from Customers

--SELECT DISTINCT---
--SADECE SECTIGIMIZ KOLONDAKI BIRBIRINEN FARKLI DEGERLERI GETIRIR
--Bazen tablomuzun kolonlarinda ayni veri birden cok kez tekrar edilebiliyor
--Customers tablosundan country kolonunun benzersiz olanlarini getirir
--3)
--select distinct country from Customers

-- COUNT(*),COUNT(COUNTRY), COUNT(DISTINCT COUNTRY)
-- Customers tablosundan country kolonunda kac tane veri var bunu buluruz burda ayni olanlarda dahil gelir
--4)
--select count(country) from Customers
--
--customers tablosunda country kolonunda benzersiz veri sayisini getirir
--5)
--select count(distinct country) from customers

--WHERE-FILTRELEME-SARTI YAZDIGIMIZ KOMUTUMUZDUR 

--SELECT column1, column2, ...FROM table_name WHERE condition;
--
--Note: The WHERE clause is not only used in SELECT statements, it is also used in UPDATE, DELETE, etc.!

--SADECE ULKESI USA OLANLARI ULKE VE SEHIR KOLONLARI ILE GETIR....
--6)
--select Country,City from customers where Country='USA'
--Sql de text leri yazarken tek tirnakla yazariz cift tirnakla hata aliriz

-- employeeId si 1 olanlardan ShipName ve ShipAddress kolonlarini getir 
--7)
--select ShipName, ShipAddress from Orders where EmployeeID=1 

--Operators in The WHERE Clause
-- =esittir, >= buyukesit, <=kucukesit , <> esit olmayan veya esit degil
-- BETWEEN ... AND...- ozellikle iki fiyat arasindaki urunleri getirmek istersek burayi kullanabiliriz..
-- fiyati 10.000 ile 20.000 arasi urunleri getir derken kullaniriz
-- 8)
--select ProductName, UnitsInStock, UnitPrice from Products where UnitPrice Between 10.000 And 20.000

--LIKE--Bas harfi istedigimiz herhangi bir harf ile baslayan bir kolonu istedigimiz diger kolonlarla 
--birlikte getirir
--9)
--select City, country from Customers where city LIKE 'S%'

--IN ('London','Berlin')=> MESELA CITY KOLONUNDAN SADECE CITY SI LONDON DEGIL DE LONDON VE BERLIN OLANLAR GELSIN 
--DERSEK IN I KULLANABILIRZ
--10)
--select City, Country from Customers where City IN ('London','Berlin')

--11)YUKARDAKI KOD LA AYNI GOREVI GORUR
--select City, Country from Customers where City='London' or City='Berlin'
--The SQL AND, OR and NOT Operators

-- <> ILE NOT BURDA AYNI GOREVI YAPIYOR AMA YAZILMA YERLERI FARKLI
--12)
-- select City,Country from Customers where city <> 'London'
--13)
--select City,Country from Customers where NOT City='London' 

--Ulkesi Germany ama sehri sadece Berlin olanlar gelsin dersek AND kullaniriz

--14)
--select City,Country from Customers where Country='Germany' and city='Berlin'
--15) ulkesi hem USA hemde Germany olanlar gelsin dersek
--select City,Country from Customers where country='Germany' or country='USA'

-- Combining AND, OR and NOT

--Ulkesi Almanya ve sehri Berlin veya Leipzig olanlar
--16)
--select City,country from Customers where country='Germany' and (city='Leipzig' or city= 'Berlin')
--	ulkesi germany ve USA olmayan ulke isimlerini sec ve kolonlardan da city ve country getir diyoruz
--17)
--select City,Country from Customers where Not country= 'Germany' and Not country='USA'

--ORDER BY.....ASC|DESC ILE AZALAN VEYA ARTAN SIRALAMALAR YAPMA

--SELECT column1, column2, ...
--FROM table_name
--ORDER BY column1, column2, ... ASC|DESC;


--A DAN Z YE ULKE SIRALAMASI YAP
--18
--select City,Country from Customers order by Country
--select City,Country from Customers order by Country asc
--Z DEN A YA ULKE SIRALAMASI YAP
--19
--select City,Country from Customers order by Country desc

--A dan Z ye ulke siralamasi yap, ulkelere karsilik gelen sehirleri de ulkelere gore A dan Z ye sirala
--20
--select City,Country from Customers order by Country,City

--Ulke siralamasi A dan Z ye sehir siralmaasi da Z den A ya ulke siralamasina gore olacak sekilde
--21
--select City,Country from Customers order by Country Asc, City Desc

--The SQL INSERT INTO Statement
--The INSERT INTO statement is used to insert new records in a table.

--INSERT INTO table_name (column1, column2, column3, ...)
--VALUES (value1, value2, value3, ...);
--22
--INSERT INTO Customers (CustomerID,CompanyName ,city,country) VALUES ('ASDFK','lkkjahfhadf'  ,'Oslo', 'Norway')

--Normalde bir veri eklenirken o veriye ait biz bir CustomerId vermeyiz biz diger tum verileri veririz
--CustomerId yi tablodak auto increment ozelliginden dolayi kendisi otomatik benzersiz bir id atar
--Eklenip eklenmedigini gormek icinde burdan cek ederiz...
--select * from Customers where Country='Norway'
--23
--INSERT INTO Customers (CustomerId,CompanyName, City, Country) VALUES ('OLKGD','Cardinal', 
--'Stavanger', 'Norway');
--Normalde CustomerId eklenmezzz bunu unutmayalimmmm.... auto-increment ile tablo otomatik ekler

--select * from Customers where Country='Norway'

--Insert Into
-- Customers 
--( CustomerName, 
--Address, 
--City, 
--PostalCode,
--Country  )

--Values
 
--( 'Hekkan Burger',
--'Gateveien 15',
--'Sandnes',
--'4306',
--'Norway')


--What is a NULL Value?
--NUll 0 dan veya bosluktan farklidir
--Null demek kayit sirasinda bos birakilan alan demektir
--Eger bir tabloda bir alan optional ise ve biz tabloya veri kaydederken o alana veri yazmazsak
--o alan null olarak doldurulacaktir.
--NULL u biz = ile veya diger normal operatorlerle test edemeyiz...
--It is not possible to test for NULL values with comparison operators, such as =, <, or <>.
--NULL SADECE IS NULL VEYA IS NOT NULL ILE TEST EDILIR

--SELECT column_names
--FROM table_name
--WHERE column_name IS NULL;
--The IS NULL Operator

--24
--select City, Country,Phone from Customers where Phone is NUll

--25
--select City,Country, Phone from Customers where Phone is not Null

--The SQL UPDATE Statement

--UPDATE table_name
--SET column1 = value1, column2 = value2, ...
--WHERE condition;

--Note: Be careful when updating records in a table! Notice the WHERE clause in the UPDATE statement.
--The WHERE clause specifies which record(s) that should be updated. If you omit the WHERE clause,
--all records in the table will be updated!
--Update islemini yaparken hangi verileri update edecegimizi yazdiktan sonra asil update islemini yapan
--yer where kosuludur where filtresidir orada hangi kaydi guncelleyecegimizi belirtmeliyiz...
--Eger where kosulu kullanmazsak tum kayitlar guncellenir

--26
--UPDATE Customers SET ContactName='Adem Erbas', city='Skien' where CustomerId='AROUT'

--select CustomerId,City,ContactName from Customers where CustomerId='AROUT'

--Be careful when updating records. If you omit the WHERE clause, ALL records will be updated!
--Dikkat edelim eger where filtresini koymazsak o zaman tum kayit guncellenir

--The SQL DELETE Statement
--DELETE FROM table_name WHERE condition;
--The DELETE statement is used to delete existing records in a table.
--Delete ifadesi tablodaki kayitlari silmek icin kullanilir yani biz satir sileriz DELETE ile
--Bundan dolayi hangi satiri sileceegimizi mutlaka where ile belirtmeliyiz yoksa tum kayitlar silinir
--Note: Be careful when deleting records in a table! Notice the WHERE clause in the DELETE statement. 
--The WHERE clause specifies which record(s) should be deleted.
--If you omit the WHERE clause, all records in the table will be deleted!
--Eger where filtresini unutursak listedeki tum kayitlar silinebilir DIKKAT!!!

--DELETE FROM table_name WHERE condition;
--Tabloyu silmeden tum kayitlari tablodan silmek de mumkundur
--DELETE FROM table_name;

--The SQL SELECT TOP Clause(MYSQL DE LIMIT DIYE GECER)
--SELECT TOP yan tümcesi, döndürülecek kayıt sayısını belirtmek için kullanılır.
--SELECT TOP yan tümcesi, binlerce kayıt içeren büyük tablolarda kullanışlıdır. 
--Çok sayıda kayıt döndürmek performansı etkileyebilir.

--SELECT TOP number|percent column_name(s)
--FROM table_name
--WHERE condition;

--WHERE ILE VERDIGIMIZ KOSULA UYAN ELEMAN SAYISINI SINIRLANDIRIIRIZ
--BU MESELA HABER SITELERINDE MESELA DERIZ KI SON 5 HABER METNI YAYINLANSIN DERIZ O ZAMAN
--BU SEKILDE SINIRLANDIRIRIZ
--27
--SELECT TOP 12 City, ContactName,Country from Customers where Country='France' 
--28
--SELECT TOP 5 * FROM Customers

--SQL TOP PERCENT Example

--29
--SELECT TOP  50 PERCENT City,Country,ContactName FROM Customers

--select * from Customers where country='Germany'

--SELECT MIN(column_name)
--FROM table_name
--WHERE condition;

--MAX() SYNTAX

--SELECT MAX(column_name)
--FROM table_name
--WHERE condition;
-- SmallestPrice adinda bir alyas atadik

--30
--select  MIN(UnitPrice) AS SmallestPrice  from Products where CategoryId=1

--31
--select MAX(UnitPrice) As BiggestPrice from Products

--The SQL COUNT(), AVG() and SUM() Functions
--count(column_name) burda kolondan kactane var onu saymak icin kullanilir

--SELECT COUNT(column_name)
--FROM table_name
--WHERE condition;

--32)
--SELECT count(City) from Customers where City='London'

--AVG() ORTALAMA ALMAK ICIN KULLANIRIZ

--SELECT AVG(column_name)
--FROM table_name
--WHERE condition;
--33
--select Avg(Unitprice) from Products where categoryId=1

--The SUM() function returns the total sum of a numeric column. 
--Sum fonksiyonu da total sayiyi getirir

--SELECT SUM(column_name)
--FROM table_name
--WHERE condition;

--SELECT COUNT(ProductID)
--FROM Products;
--Note: NULL values are not counted.

--SELECT AVG(UnitPrice)
--FROM Products;
--Note: NULL values are ignored.

--SELECT SUM(Quantity)
--FROM [Order Details]

--Note: NULL values are ignored.

--The SQL LIKE Operator
--The LIKE operator is used in a WHERE clause to search for a specified pattern in a column.
--SELECT column1, column2, ...
--FROM table_name
--WHERE columnN LIKE pattern;
-- The percent sign (%) represents zero, one, or multiple characters
 --The underscore sign (_) represents one, single character

--Tip: You can also combine any number of conditions using AND or OR operators.
--Here are some examples showing different LIKE operators with '%' and '_' wildcards:

--WHERE CustomerName LIKE 'a%'	Finds any values that start with "a"
--WHERE CustomerName LIKE '%a'	Finds any values that end with "a"
--WHERE CustomerName LIKE '%or%'	Finds any values that have "or" in any position
--WHERE CustomerName LIKE '_r%'	Finds any values that have "r" in the second position
--WHERE CustomerName LIKE 'a_%'	Finds any values that start with "a" and are at least 2 characters in length
--WHERE CustomerName LIKE 'a__%'	Finds any values that start with "a" and are at least 3 characters in length
--WHERE ContactName LIKE 'a%o'	Finds any values that start with "a" and ends with "o"

--City kolonunda 'l' harfi ile baslayan city leri getir demek
-- 34)

--select ContactName,City from Customers  where City LIKE 'l%'  

-- city isminin son harfi 'n' ile biten sehir isimlerini ve onunla beraber contactName leri getir demektir
--35
--select ContactName,City from Customers where City LIKE '%n'

--CITY ISMI ICERISINDE 'ON' KELIMESI OLAN CITY LERI VE ONUN SATIRINDAKI CONTACTNAME LERI GETIR DEMEKTIR
--36
--select ContactName, City from Customers where city LIKE '%on%'

--City kolonunda ikinci harfi o olan cityleri getir demektir
--37
--select ContactName, City from Customers where city LIKE '_o%'

--'l' ile başlayan ve en az 2 karakter uzunluğundaki değerleri bulur(1 tane l var bir de alt cizgi tek 
--karakteri temsil eder onu 2 alt cizgi yaparsak o zaman hem 'l' ile baslayan hemde en az 3 karaketerli
-- olan city namelerini getirmis olur

--38
--select ContactName, city from customers where city LIKE 'l_%'
--select ContactName, city from customers where city LIKE 'l__%'

--city ismi s ile baslayan n ile biten cityisimlerini getir demis oluruz
--39
--select ContactName,city from customers where city LIKE 's%n'

--COK ONEMLI BUNLAR GERCEK WEB SITELERINDE COKK KULLANILIYOR

-- City Name i 'ber' ile baslayan city lerin tum kolonlarini getir
--40
--SELECT * FROM Customers WHERE City LIKE 'ber%'

-- city name icerisinde 'es' olan tum city leri tum kolonlari ile birlikte getir
--41
--SELECT * FROM Customers WHERE City LIKE '%es%';

-- city ismi ilk harfinde herhangi bir karakter olan ama devaminda 'ondon' ile devam eden city leri getir
--42
--SELECT * FROM Customers WHERE City LIKE '_ondon';

-- city ismi l ile baslyan ikinci harfinde herhangi bir karakter sonraki harfi 'n' bir sonraki yine
--herhangi bir karakter olan ve en son iki harfi 'on' ile biten city isimlerini getir
--43
--SELECT * FROM Customers WHERE City LIKE 'L_n_on'; 

-- city ismi b,s veya p ile baslyanlari getir
--44
--SELECT * FROM Customers WHERE City LIKE '[bsp]%';

-- city ismi a,b veya c ile baslayan city isimlerini getir
--45
--SELECT * FROM Customers WHERE City LIKE '[a-c]%';

--b,s veya p ile baslamayan city isimlerini getir
--46
--SELECT * FROM Customers WHERE City LIKE '[!bsp]%';
--SELECT * FROM Customers WHERE City NOT LIKE '[bsp]%';

--The SQL IN Operator
--The IN operator allows you to specify multiple values in a WHERE clause.
--In operatoru bircok degeri where ile filtrelerken kullanabilmeni sagliyor
--The IN operator is a shorthand for multiple OR conditions.
-- in operatoru birden fazla or kullanmak yerine onu kisa halidir

--SYNTAX
--SELECT column_name(s)
--FROM table_name
--WHERE column_name IN (value1, value2, ...);

--SELECT column_name(s)
--FROM table_name
--WHERE column_name IN (SELECT STATEMENT);

--ulkesi germany,france,norway olan tabloyu city ile beraber getir

 --47
 --select Country,City from Customers where country in ('Germany', 'France','Norway')
-- select Country, City from Customers where country in (select Country from Suppliers)

--BURAYA DIKKATTT!!!!!
  --DIKKAT EDELIM BURDA IN() DEN SONRAKI PARANTEZE BIZ SONUCU ULKE DONEN BIR TABLO YAZDIK!!!!!!!
 --48
 --select Country, City from Customers where country in (
  --select Country from Suppliers where country in ('Germany','Norway')
  --)

  -- NORVEC VE ALMANYA HARICINDEKI ULKELERI GETIR DIYELIM MESELA!!!!

  --49
  --select Country,City from Customers where country NOT in ('Germany', 'Norway')


  --The SQL BETWEEN Operator
--The BETWEEN operator selects values within a given range. The values can be numbers, text, or dates.

--The BETWEEN operator is inclusive: begin and end values are included. 

--BETWEEN SYNTAX
--SELECT column_name(s)
--FROM table_name
--WHERE column_name BETWEEN value1 AND value2;

-- 10.000 ile 20.000 arasindaki fiyat araligini getiririz
--50
--SELECT ProductName,UnitPrice from Products where UnitPrice BETWEEN 10.000 AND 20.000 
--10.000 ILE 20.000 ARASINDA OLMAYAN FIYAT ARALIGINI GETIRIRIZ
--SELECT ProductName,UnitPrice from Products where UnitPrice NOT BETWEEN 10.000 AND 20.000 

-- fiyati 10 ve 20 arasinda olan ve kategoriId si 4,5,8 olmayan listeeyi getir diyor
--51
--SELECT * FROM Products
--WHERE UnitPrice BETWEEN 10 AND 20
--AND CategoryID NOT IN (4,5,8);

--IKI TARIH ARASI LISTEYI GETIRME
--52
--SELECT * FROM Orders
--WHERE OrderDate BETWEEN '1996-07-01' AND '1996-07-31'

--53
--SELECT * FROM Products
--WHERE ProductName NOT BETWEEN 'Ikura' AND 'Pavlova'
--ORDER BY ProductName;

--SQL Aliases
--SQL aliases are used to give a table, or a column in a table, a temporary name.

--Aliases are often used to make column names more readable.

--An alias only exists for the duration of that query.

--An alias is created with the AS keyword.

--Alias Column Syntax

--SELECT column_name AS alias_name
--FROM table_name;

--Alias Table Syntax

--SELECT column_name(s)
--FROM table_name AS alias_name;
--
--Cagirdigimiz tablo gelirken alyas olarakk verdigimiz isimlerle gelecektir
--54
--select City as sehir, Country as ulke from customers where city='London'


--TABLOYA ATADIGIMIZ MAHLASLA KARISTIRMA....
--55
--select city, country from customers c where c.City='Berlin'

--Burda biz tabloda kolon adi olan Adress, PostalCode ve City ve Country kolon adlarini

-- Adress isminde birlestiririz......
--56
--SELECT ContactName, CONCAT(Address,', ',PostalCode,', ',City,', ',Country) AS Address
--FROM Suppliers;

--Alias for Tables Example
--57
--SELECT o.OrderID, o.OrderDate, c.ContactName
--FROM Customers AS c, Orders AS o
--WHERE c.ContactName='Hanna Moos' AND c.CustomerID=o.CustomerID;

--SQL JOIN-- INNER JOIN---HER IKI TABLODA DA ORTAK BULUNAN BIR ID UZERINDEN TABLOLARI BIRLESTIRME
---Biz bir urunun tablomuzda bilgilerini alirken tablomuzda categoryId sini tutariz sadece
--ama o kategorinin neler oldgunu on yuzde gosterirken id vermeyiz ismini veririz dolayisi ile 
--de ana tablomuzda categoryId vardir sadece ve ayrica bir de categories tablomuza gidip
--ordaki verileri de urunle ilgili verilerle birlestirmemiz gerekiyor
--A JOIN clause is used to combine rows from two or more tables, based on a related 
--column between them.

--58

--select c.ContactName as Iletisim, c.city, o.OrderDate from Customers c inner join Orders o 
--on c.CustomerID=o.CustomerID


--Different Types of SQL JOINs
--Here are the different types of the JOINs in SQL:

--(INNER) JOIN: Returns records that have matching values in both tables
--LEFT (OUTER) JOIN: Returns all records from the left table, and the matched records
--from the right table
--RIGHT (OUTER) JOIN: Returns all records from the right table, and the matched records
--from the left table
--FULL (OUTER) JOIN: Returns all records when there is a match in either left or right table


--HIC SATILMAMIS URUNLERI GETIR--HIC ORDER YAPILMAMIS YANI
-- PRODUCT TABLOSUNDA VAR OLAN ORDERID AMA ORDERDETAILS DE  TABLOSUNDA YOK DIYELIM KI
-- BIZDE KAYITLI AMA BIZDEN HIC ALISVERIS YAPMAMIS MUSTERILERI GETIR..


--3 TABLO ILE INNER JOIN YAPMA!!!!!!ONEMLI!!!!!!!!!!!!!!!!!
--JOIN Three Tables
--59
--/////////////////////////////////////////////////////////////////
--SELECT Products.ProductID, Products.ProductName, Categories.CategoryName, Suppliers.CompanyName 
--FROM (--
--(Products INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID)

--INNER JOIN Suppliers ON Products.SupplierID = Suppliers.SupplierID)
--///////////////////////////////////////////////////////////////////////
--3 TABLOYU BIRDEN BIRLESTIRDIK...
-- INNER JOIN DEN ONCE YAZILAN ANA TABLOUMUZU YINE INNER JOIN SONUCUNDA GELEN BIR TABLO YAPTIK
-- PRODUCTS ILE CATEGORIES TABLOSU IKISINDE DE ORTAK OLAN CATEGORYID BIRLESIMINDEN BIR TABLO
--ORTAYA CIKTI VE BU ORTAYA CIKAN TABLO ANA TABLOMUZ
--BU ORTAYA CIKAN ANA TABLOYA INNER JOIN DEDIK VE ORTAYA CIKAN TABLO ILE BIRLESTIRECEGIMIZ TABLO 
-- ISE SUPPLIERS TABLOSU OLDU VE BURDA DA YINE PRODUCTS ICINDEKI SUPPLIERID ILE 
--SUPPLIERS.SUPPLIERID YI ESLESTIREREK INNER JOIN I TAMAMLAMIS OLDUK VE BOYLELIKLE 3. TABLOYU DA 
-- ISIN ICINE DAHIL ETMIS OLDUK

--SQL Self Join
--A self join is a regular join, but the table is joined with itself.

--Self Join Syntax
--SELECT column_name(s)
--FROM table1 T1, table1 T2
--WHERE condition;
--T1 and T2 are different table aliases for the same table.
--Ayni tablodan olusturulmus 2 alyas i birbiri ile karsilastiriyrouz ve
-- sehirleri ayni olan ama customerId si farkli olanlari getir diyoruz
--60

--SELECT A.CustomerID,A.ContactName AS ContactName1,B.CustomerID ,B.ContactName AS ContactName2, A.City
--FROM Customers A, Customers B
--WHERE A.CustomerID <> B.CustomerID
--AND A.City = B.City
--ORDER BY A.City;


--The SQL UNION Operator
--The UNION operator is used to combine the result-set of two or more SELECT statements.

--Every SELECT statement within UNION must have the same number of columns
--The columns must also have similar data types
--The columns in every SELECT statement must also be in the same order
--Iki tane select ifademizi birlestirmek icin union kullaniriz ama her iki select ifadesinde de
-- kolon sayisi esit olmalidir
--Her iki select teki kolona da ayni kolon isimleri gelmeli ve ayni sayida kolon isimleri gelmeli

--61
--SELECT City,ContactName,ContactTitle FROM Customers
--UNION
--SELECT City, CompanyName, Address FROM Suppliers
--ORDER BY City;


--62

--SELECT City, Country FROM Customers
--WHERE Country='Germany'
--UNION
--SELECT City, Country FROM Suppliers
--WHERE Country='Germany'
--ORDER BY City;


--SQL GROUP BY İfadesi
--GROUP BY ifadesi, aynı değerlere sahip satırları "her ülkedeki müşteri sayısını bul" 
--gibi özet satırlarda gruplandırır.
--GROUP BY ifadesi, sonuç kümesini bir veya daha fazla sütunla gruplandırmak için
--genellikle toplama işlevleriyle (COUNT(), MAX(), MIN(), SUM(), AVG()) kullanılır.

--GROUP BY Syntax
--SELECT column_name(s)
--FROM table_name
--WHERE condition
--GROUP BY column_name(s)
--ORDER BY column_name(s);

--SELECT COUNT(SupplierId), Country
--FROM Suppliers
--GROUP BY Country;

-- Categoryid den Products tablosunda kacartane var bakiyoruz
-- urun sayisi 10 dan az kalmis urunleri getiriyoruz
--URUN CESIDI 10 TANE DEN AZ OLAN URUN KATEGORILERININ SAYISI GETIRMEMIZ
--ISTENIRSE ASAGIDAKI SORGUYU YA
--select CategoryId, count(*) from Products group by CategoryId having count(*)<10

--select ContactTitle, count(SupplierID) from Suppliers group by ContactTitle
--Burda ContactTitle baslıgı aynı olan kac tane satır var onu buluyoruz
-- oncelikle group by i (COUNT(), MAX(), MIN(), SUM(), AVG()) islevleri ile kullanabiliriz
-- Ayrica select ten sonra yazdigimiz kolon ismi ile group by dan sonra yazdigimiz ayni olmali
-- count() olarak count(*) veya count(SupplierId) arasinda cok fark yok cunku * tek tek satir
--lari sayar zaten her bir satir da kendine ozel farkli bir id dir o yuzden aslinda
--her ikisinde de ayni seyi saymis oluyoruzz

--GROUP BY With JOIN Example

--SELECT CompanyName, COUNT(Products.ProductID) AS NumberOfProducts FROM Products
--LEFT JOIN Suppliers ON Products.SupplierID = Suppliers.SupplierID
--GROUP BY CompanyName;

--The SQL HAVING Clause

--Having Syntax
--SELECT column_name(s)
--FROM table_name
--WHERE condition
--GROUP BY column_name(s)
--HAVING condition
--ORDER BY column_name(s);


--Select CategoryId, count(CategoryID) from Products group by CategoryId having count(*) < 10
--Categori olarak 10 dan daha az adeti kalmis urunler CategoryId leri ve karsilarinda
--kacar tane urun varsa o karsimiza gelir

--100 tane nin uzerinde siparis veren musterilerin isim soy isimlerini istedi mesela
--patron bizden istedi mesela

--select LastName, FirstName, count(OrderID) as numberofOrder from (
--Orders inner join Employees ON Orders.EmployeeID=Employees.EmployeeID)
--group by  LastName, FirstName having count(*) >50

--
--soyisimleri King ve Fuller olan calislanlarin 50 den fazla siparisi olani getir
--select LastName,FirstName, count(OrderId) as NumberOfOrder from (
--Orders inner join Employees ON  Orders.EmployeeID=Employees.EmployeeID)
--where LastName='King' OR LastName='Fuller'
--group by LastName, FirstName having count(*)> 50

--Biz normalde soy ismi de getirebilmek icin orders ile employees tablosunu inner join ederiz..



--EXIST
--SELECT ContactName
--FROM Suppliers
--WHERE EXISTS (SELECT ProductName FROM Products WHERE Products.SupplierID = Suppliers.supplierID
--AND UnitPrice < 20);

--Exist kullanımı
--"SQL Sorguları" ile ilgili 0 yazı bulundu.
--EXIST, bir sorgudan sonucun dönüp dönmediğini belirten bir sql cümleciğidir. 
--"EXIST" kullanımı "IN" kullanımı ile aynı sonucu verir. 
--Ancak "EXIST" kullanımı performans açısından çok hızlıdır.
--EXIST cümleciğinin geri dönüş tipi True veya False şeklindedir. 
--İçerisine aldığı subquery'den herhangi bir sonuç geriye dönüyorsa TRUE hiç bir
--kayıt geri dönüşü yoksa False döndürür. Yani karşılaştırma yaparken True sonucunu
--aldığı anda döngüden çıkar. IN ise, ana sorgudan gelen her kaydı kontrol etmek 
--için IN içerisinde bulunan alt sorgudaki tüm kayıtları kontrol eder.

--SELECT * FROM Haber as h 
--WHERE EXISTS(SELECT null)

--Exists(Select Null) ifadesi True değerini döndürür.


--Aşağıdaki SQL deyimi, OrderDetails tablosunda Quantity'nin 10'a eşit HERHANGİ bir kaydı
--bulursa ProductName'i listeler (Quantity sütununda bazı 10 değerleri olduğundan bu, 
--TRUE değerini döndürür):

--SELECT ProductName
--FROM Products
--WHERE ProductID = ANY
--  (SELECT ProductID
--  FROM [Order Details]
--  WHERE Quantity =10);

--ALL
--ALL fonksiyonu parametre olarak içerisine aldığı subqueryden geriye dönen sonuçların 
--tamamı karşılatırma kriterine uyuyorsa TRUE herhangi biri uymuyorsa FALSE döndürür.


--select ProductName,UnitPrice from Products as p where 20.000> ALL(select UnitPrice from [Order Details] as od
--where p.ProductId=od.ProductId) 

--SOME - ANY
--SOME - ANY fonksiyonları parametre olarak içerisine aldığı subqueryden geriye dönen
--sonuçların herhangi bir tanesi karşılatırma kriterine uyuyorsa TRUE hiç biri uymuyorsa
--FALSE döndürür.


--The SQL SELECT INTO Statement
--The SELECT INTO statement copies data from one table into a new table.

--SELECT INTO Syntax

--SELECT *
--INTO newtable [IN externaldb]
--FROM oldtable
--WHERE condition;

--Copy only some columns into a new table:

--SELECT column1, column2, column3, ...
--INTO newtable [IN externaldb]
--FROM oldtable
--WHERE condition;

--The new table will be created with the column-names and types as 
--defined in the old table. You can create new column names using the AS clause.

--Tip: SELECT INTO can also be used to create a new, empty table using the schema of another.
--Just add a WHERE clause that causes the query to return no data:

--SQL SELECT INTO Nedir, Nasıl Kullanılır?
--SQL SELECT INTO, Bir tablo üzerinde riskli bir işlem yapılacağında veya
--o tablonun yedeğini almak istediğimiz durumlarda SELECT INTO cümlesi imdadımıza yetişir.


---- Bu sql cümlesinde istersek harici bir veritabani içerisinden 
-- -- tablo1 adındaki tablonun kopyasını yenitablo adındaki tabloya alıyoruz
 
-- SELECT * 
-- INTO yenitablo [hariciVeritabanı] 
-- FROM tablo1;

--Tablonun belirtilen alanlarıyla yedeğini alma
--From’dan sonra belirtilen tablo1 adı yazan kısma yedeği alınacak alanların bulunduğu
--tablonun adı yani alttaki örneğe göre tablo1 adı yazılmıştır.
--Üstteki örnekten farkı tüm tablonun yedeği değilde sadece yedeğini almak istediğimiz
--alanların adını alttaki örnekte kolon_adları kısmına yazmamız gereklidir.

-- Bu sql cümlesinde istersek harici bir veritabani içerisinden tablo1 
-- adındaki tablonun sadece belirtmiş olduğumuz alanların yedeğini almaktayız
 
 --SELECT kolon_adları 
 --INTO yenitablo [hariciVeritabanı] 
 --FROM tablo1;

-- Tablonun yedeğini alma
--Aynı veritabanı içerisindeki tablonun yedeğini almak için yukarıdaki örneklerde
--olduğu gibi ‘select *’ ile tüm kolonların yedeğini almak istediğimizi
--ve into’da belirtilen ‘MusterilerYedek2013’ yeni bir tablo adıyla From
--kısmında belirtilen Musteriler tablosunun yedeği alınmaktadır.

-- Bu sql cümlesi ile Musteriler tablosundaki tüm kayıtlar MusterilerYedek2013 
-- adlı yeni tablo oluşturulacak ve tüm kayıtların yedeği alınacaktır.
 --SELECT * 
 --INTO MusterilerYedek2013 
 --FROM Musteriler;


-- Harici tablodan yedek alma örneği
--Harici veritabanı içerisindeki tablonun yedeğini almak için yukarıdaki örneklerde 
--olduğu gibi ‘select *’ ile tüm kolonların yedeğini almak istediğimizi 
--ve into’da belirtilen ‘MusterilerYedek2013’ yeni bir tablo adıyla From 
--kısmında belirtilen Musteriler tablosunun yedeği alınmaktadır. 
--IN kelimesi ilede hangi harici veritabanından yedek alınacağı belirtilmektedir.

-- Bu sql cümlesi ile Yedek.mdb veritabanında Musteriler tablosundaki 
-- tüm kayıtlar MusterilerYedek2013 adlı yeni tablo oluşturulacak 
-- ve tüm kayıtların yedeği alınacaktır.
 
 --SELECT *
 --INTO MusterilerYedek2013 IN 'Yedek.mdb' 
 --FROM Musteriler;


-- Sadece belirli alanların yedeğini alma örneği
--WHERE cümlesindeki koşullara göre tablonun yedeğini almayı bu örnekte görebilirsiniz.

-- SELECT *
-- INTO MusterilerYedek2013
-- FROM Musteriler
-- WHERE Ulke='Türkiye';

--JOIN ile tabloların birleşiminden oluşan sonucun yedeğini bir tabloya kaydetme
--JOIN ile tablolarin birlesimi sonucunda yedeğini almak istediğimiz kodları yazdıktan 
--sonra MusterilerYedek2013 adlı yeni tabloya verilerimiz yedeklenecektir.


-- SELECT Musteriler.MusteriAdi, Siparisler.SiparisID
-- INTO MusterilerYedek2013
-- FROM Musteriler
-- LEFT JOIN Siparisler
-- ON Musteriler.MusteriID=Siparisler.MusteriID;

--İpucu:Tabloların kaydınının yedeğini almadan sadece yapısınının yedeğini almak 
--istediğiniz durumlarda aşağıdaki sorgu işinize yarayacaktır. 
--Where cümlesindeki 1 eşitse 0’a ifadesi her zaman yanlış sonuc olarak
--değerlendirileceği için hiçbir kayıt gelmeyecektir ve böylece sadece 
--tablonun yedeğini alabileceksiniz.

-- SELECT *
-- INTO yenitablo
-- FROM tablo1
-- WHERE 1=0;


--SQL INSERT INTO SELECT Komutu
--INSERT INTO SELECT komutu, bir tablodaki verileri kopyalar ve başka bir tabloya ekler.


--INSERT INTO SELECT, kaynak ve hedef tablolardaki veri türlerinin eşleşmesini gerektirir.


--Hedef tablodaki mevcut verileri etkilemez.

--Tüm tabloyu başka bir tabloya kopyalamak için:

--INSERT INTO tablo2
--SELECT * FROM tablo1
--WHERE koşul;

--Tablodaki sadece bazı sütunları başka bir tabloya kopyalamak için ;

--INSERT INTO tablo2 (sütun1, sütun2, sütun3, ...)
--SELECT sütun1, sütun2, sütun3, ...
--FROM tablo1
--WHERE koşul;

--SQL INSERT INTO SELECT Örnekleri:

--Aşağıdaki SQL komutu "Tedarikçiler" tablosunu "Müşteriler" tablosuna kopyalar.

--NOT: Verilerle doldurulmayan sütunlar NULL içerecektir.

--INSERT INTO Musteriler (Ad, Sehir, Ulke)
--SELECT TedarikciAdi, Sehir, Ulke FROM Tedarikciler;

--Aşağıdaki SQL komutu “Tedarikciler” tablosundaki belirtilen Sütunları  
--“Musteriler” tablosuna kopyalar.
--INSERT INTO Musteriler (Ad, Soyad, Adres, Sehir, PostaKodu, Ulke)
--SELECT TedarikciAdi, CalisanAd, Adres, Sehir, PostaKodu, Ulke FROM Tedarikciler;

--Aşağıdaki SQL kodu sadece Alman Tedarikçileri kopyalar.

--INSERT INTO Musteriler (Ad, Sehir, Ulke)
--SELECT TedarikciAdi, Sehir, Ulke FROM Tedarikciler
--WHERE Ulke='Almanya';

--SELECT OrderID, Quantity,
--CASE WHEN Quantity > 30 THEN 'The quantity is greater than 30'
--WHEN Quantity = 30 THEN 'The quantity is 30'
--ELSE 'The quantity is under 30'
--END AS QuantityText
--FROM OrderDetails;



--TABLOYA KOLON EKLE
--ALTER TABLE [Order Details] 
--ADD KazanilanTutar varchar




--TABLODAN KOLON SIL
--ALTER TABLE [Order Details]
--Drop column KazanilanTutar


--SELECT CompanyName, COUNT(Products.ProductID) AS NumberOfProducts FROM Products
--LEFT JOIN Suppliers ON Products.SupplierID = Suppliers.SupplierID
--GROUP BY CompanyName;

--select ProductName, UnitPrice from Products where ProductName='Alice Mutton'





---  SQL ODEV-----

--Her bir üründen toplamda ne kadar para kazandığımızı bulunuz.

--İpucu : Group by kullanılacak

--İpucu : Products, Orders, Order Details tabloları join edilecek.

--İpucu : Sum kullanılacak.

--Sonuç aşağıdaki formatta olmalıdır.

--Ürün Adı, Kazanılan Toplam Miktar


--Not : Kazanılan tutar toplamı Order Details tablosunda unitPrice ve quantity alanlarının çarpımından beslenecek.

--Ödevinize ait sql kodunu paylaşınız.

SELECT ProductName, SUM([Order Details].UnitPrice* [Order Details].Quantity) as KazanilanTutar 
FROM Products INNER JOIN [Order Details] ON Products.ProductID=[Order Details].ProductID
GROUP BY ProductName


SELECT ProductName, SUM([Order Details].UnitPrice* [Order Details].Quantity) as KazanilanTutar 
FROM  
(
PRODUCTS INNER JOIN [Order Details] ON Products.ProductID=[Order Details].ProductID
)  INNER JOIN ORDERS ON  
[Order Details].OrderID = Orders.OrderID

GROUP BY ProductName

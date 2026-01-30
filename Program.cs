class Program{

    static List <Dictionary<string,object>> dolgozokBeolvasas(){

        List <Dictionary<string,object>> dolgozok = new List <Dictionary<string,object>>();
        try
        {
            using(StreamReader sr = new StreamReader("berek2020.txt")){
            sr.ReadLine();

            string sor;
            while((sor =sr.ReadLine()) != null){
                try
                {
                    string[] adatok = sor.Split(';');
                    var dolgozo= new Dictionary<string,object>();
                    dolgozo["nev"]=adatok[0];
                    dolgozo["neme"]=adatok[1];
                    dolgozo["reszleg"]=adatok[2];
                    dolgozo["belepes"]=adatok[3];
                    dolgozo["ber"]=int.Parse(adatok[4]);
                    dolgozok.Add(dolgozo);
                }
                catch (Exception)
                {
                    //he egy sor hibás átugorjuk
                    continue;
                }
               
            }
        }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Hiba: A áfjl nem található");
        }
        catch(Exception ex)
        {
            Console.WriteLine("Hiba: a beolvasás során, " + ex.Message);
        }
      
        return dolgozok; 
    }

    static void kiir(List <Dictionary<string,object>> dolgozok){
        foreach (var dolgozo in dolgozok)
        {
            Console.WriteLine(
                $"Név: {dolgozo["nev"]}, " +
                $"Neme: {dolgozo["neme"]}, " +
                $"Részleg: {dolgozo["reszleg"]}, " +
                $"Belépés: {dolgozo["belepes"]}, " +
                $"Bér: {dolgozo["ber"]}"
            );
        }
    }

    static int dolgozokSzama(List <Dictionary<string,object>> dolgozok){
        return dolgozok.Count();
    }

    static void Main(){

        List <Dictionary<string,object>> Mechwart_dolgozoi= dolgozokBeolvasas();
        kiir(Mechwart_dolgozoi); 
        Console.WriteLine("A dolgozók száma:", dolgozokSzama(Mechwart_dolgozoi));
    }
}
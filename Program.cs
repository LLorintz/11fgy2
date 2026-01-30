using System.Text;
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

    static double atlagber(List <Dictionary<string,object>> dolgozok)
    {
        double osszeg = 0;

        foreach (var dolgozo in dolgozok)
        {
            osszeg+=Convert.ToInt32(dolgozo["ber"]);

        }

        double atlag= osszeg/dolgozok.Count();
        atlag = atlag/1000;
        atlag = Math.Round(atlag,1);

        return atlag;
    }

    static void LegmagasabbFizetes(List <Dictionary<string,object>> dolgozok, string keresettReszleg)
    {
        Dictionary<string,object> legmagasabb = null;
        int maxFizetes = -1;

        foreach (var dolgozo in dolgozok)
        {
            if(dolgozo["reszleg"].Equals(keresettReszleg))
            {
                int aktualisfizetes= Convert.ToInt32(dolgozo["ber"]);

                if (aktualisfizetes>maxFizetes)
                {
                    maxFizetes=aktualisfizetes;
                    legmagasabb=dolgozo;
                }
            }
        }

        if(legmagasabb!=null)
        {
             Console.WriteLine(
                $"Név: {legmagasabb["nev"]}, " +
                $"Neme: {legmagasabb["neme"]}, " +
                $"Részleg: {legmagasabb["reszleg"]}, " +
                $"Belépés: {legmagasabb["belepes"]}, " +
                $"Bér: {legmagasabb["ber"]}"
            );
        }
    }

    static void reszlegBeker(List <Dictionary<string,object>> dolgozok)
    {
        string bemenet = Console.ReadLine();

        bool vanEIlyen=false;

        foreach (var dolgozo in dolgozok)
        {
            if(dolgozo["reszleg"].Equals(bemenet))
            {
                vanEIlyen = true;
                break;
            }
        }

        if (vanEIlyen)
        {
            Console.WriteLine("van ilyen részleg");
            LegmagasabbFizetes(dolgozok,bemenet);
        }
        else
        {
            Console.WriteLine("nincs ilyen");
        }
    }


    static void Main(){
        Console.InputEncoding = Encoding.Unicode;
        List <Dictionary<string,object>> Mechwart_dolgozoi= dolgozokBeolvasas();
        kiir(Mechwart_dolgozoi); 
        Console.WriteLine($"A dolgozók száma: {dolgozokSzama(Mechwart_dolgozoi)}");
        Console.WriteLine($"A dolgozók átlagbére: {atlagber(Mechwart_dolgozoi)}");
        reszlegBeker(Mechwart_dolgozoi);
    }
}
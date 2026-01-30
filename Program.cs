class Program{

    static List <Dictionary<string,object>> dolgozokBeolvasas(){

        List <Dictionary<string,object>> dolgozok = new List <Dictionary<string,object>>();

        using(StreamReader sr = new StreamReader("berek2020.txt")){
            sr.ReadLine();

            string sor;
            while((sor =sr.ReadLine()) != null){
                string[] adatok = sor.Split(';');
                var dolgozo= new Dictionary<string,object>();
                dolgozo["nev"]=adatok[0];
                dolgozo["neme"]=adatok[1];
                dolgozo["reszleg"]=adatok[2];
                dolgozo["belepes"]=adatok[3];
                dolgozo["ber"]=adatok[4];

                dolgozok.Add(dolgozo);
            }
        }
        return dolgozok; 
    }

    static void kiir(List <Dictionary<string,object>> dolgozok){
        foreach (var dolgozo in dolgozok)
        {
            Console.WriteLine(
                $"Név: {dolgozo["nev"]}," +
                $"Neme: {dolgozo["neme"]}," +
                $"Részleg: {dolgozo["reszleg"]}," +
                $"Belépés: {dolgozo["belepes"]}," +
                $"Bér: {dolgozo["nev"]},"
            );
        }
    }

    static void Main(){

        List <Dictionary<string,object>> Mechwart_dolgozoi= dolgozokBeolvasas();
        kiir(Mechwart_dolgozoi); 

    }
}
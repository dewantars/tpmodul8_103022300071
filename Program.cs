using System;
using tpmodul8_103022300071;

class Program
{
    static void Main(string[] args)
    {
        double min, max;
        double fr;
        CovidConfig config = CovidConfig.LoadConfig("covid_config.json");

        Console.Write($"Berapa suhu badan anda saat ini? (dalam nilai {config.satuan_suhu}): ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = Convert.ToInt32(Console.ReadLine());

        if (config.satuan_suhu.ToLower() == "celcius")
        {
            min = 36.5;
            max = 37.5;
        }
        else
        {
            min = 97.7;
            max = 99.5;
        }

        if (suhu < min && suhu > max && hari > Convert.ToInt32(config.batas_hari_deman))
        {
            Console.WriteLine(config.pesan_ditolak);
        }
        else
        {
            Console.WriteLine(config.pesan_diterima);
        }

        config.UbahSatuan();
        Console.WriteLine("Satuan suhu diubah menjadi: " + config.satuan_suhu);
        
        if (config.satuan_suhu == "fahrenheit")
        {
            fr = (suhu * 9 / 5) + 32;
        }
        else
        {
            fr = (suhu - 32) * 5 / 9;
        }

        Console.WriteLine("Suhu badan setelah dikonversi: "  + fr + " fahrenheit");

    }
}
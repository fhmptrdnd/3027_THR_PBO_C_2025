using System;

class Karyawan
{
    private string nama;
    private string ID;
    private double gajiPokok;

    public Karyawan(string nama, string ID, double gajiPokok)
    {
        this.nama = nama;
        this.ID = ID;
        this.gajiPokok = gajiPokok;
    }

    public string GetNama() { return nama; }
    public string GetID() { return ID; }
    public double GetGajiPokok() { return gajiPokok; }

    public void SetNama(string nama) { this.nama = nama; }
    public void SetID(string ID) { this.ID = ID; }
    public void SetGajiPokok(double gajiPokok) { this.gajiPokok = gajiPokok; }

    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

class KaryawanTetap : Karyawan
{
    public KaryawanTetap(string nama, string ID, double gajiPokok)
        : base(nama, ID, gajiPokok) { }

    public override double HitungGaji()
    {
        return GetGajiPokok() + 500000; 
    }
}

class KaryawanKontrak : Karyawan
{
    public KaryawanKontrak(string nama, string ID, double gajiPokok)
        : base(nama, ID, gajiPokok) { }

    public override double HitungGaji()
    {
        return GetGajiPokok() - 200000; 
    }
}

class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string ID, double gajiPokok)
        : base(nama, ID, gajiPokok) { }

    public override double HitungGaji()
    {
        return GetGajiPokok();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Jenis Karyawan:");
        Console.WriteLine("1. Karyawan Tetap");
        Console.WriteLine("2. Karyawan Kontrak");
        Console.WriteLine("3. Karyawan Magang");

        Console.Write("Pilih jenis karyawan (1/2/3): ");
        string jenis = Console.ReadLine();

        Console.Write("Masukkan Nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID: ");
        string ID = Console.ReadLine();

        Console.Write("Masukkan Gaji Pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;

        if (jenis == "1")
        {
            karyawan = new KaryawanTetap(nama, ID, gajiPokok);
        }
        else if (jenis == "2")
        {
            karyawan = new KaryawanKontrak(nama, ID, gajiPokok);
        }
        else if (jenis == "3")
        {
            karyawan = new KaryawanMagang(nama, ID, gajiPokok);
        }
        else
        {
            Console.WriteLine("Pilihan tidak valid.");
            return;
        }

        Console.WriteLine("\nInformasi Karyawan:");
        Console.WriteLine("Nama: " + karyawan.GetNama());
        Console.WriteLine("ID: " + karyawan.GetID());
        Console.WriteLine("Gaji Akhir: Rp. " + karyawan.HitungGaji().ToString("#,0.00", System.Globalization.CultureInfo.GetCultureInfo("id-ID")));
    }
}

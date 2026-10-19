using System;
using System.Collections.Generic;

class Item
{
    public string Judul { get; set; }
    public int Tahun { get; set; }

    public Item(string judul, int tahun)
    {
        Judul = judul;
        Tahun = tahun;
    }

    public virtual string Deskripsi()
    {
        return $"Item: {Judul}, tahun {Tahun}";
    }

    public void InfoItem()
    {
        Console.WriteLine(Deskripsi());
    }
}

class Buku : Item
{
    public string Penulis { get; set; }

    public Buku(string judul, int tahun, string penulis)
        : base(judul, tahun)
    {
        Penulis = penulis;
    }

    public string CekPenulis()
    {
        return $"Penulis: {Penulis}";
    }

    public override string Deskripsi()
    {
        return $"Buku: {Judul} ({Tahun}), penulis {Penulis}";
    }
}

class Majalah : Item
{
    public int Edisi { get; set; }

    public Majalah(string judul, int tahun, int edisi)
        : base(judul, tahun)
    {
        Edisi = edisi;
    }

    public string InfoEdisi()
    {
        return $"Edisi: {Edisi}";
    }

    public override string Deskripsi()
    {
        return $"Majalah: {Judul} ({Tahun}), edisi {Edisi}";
    }
}

class Novel : Buku
{
    public string Sinopsis { get; set; }

    public Novel(string judul, int tahun, string penulis, string sinopsis)
        : base(judul, tahun, penulis)
    {
        Sinopsis = sinopsis;
    }

    public string BacaSinopsis()
    {
        return Sinopsis;
    }

    public override string Deskripsi()
    {
        return $"Novel: {Judul} ({Tahun}), penulis {Penulis}";
    }
}

class Komik : Buku
{
    public Komik(string judul, int tahun, string penulis)
        : base(judul, tahun, penulis)
    {
    }

    public string TampilkanIlustrasi()
    {
        return $"Ilustrasi komik {Judul} ditampilkan.";
    }

    public override string Deskripsi()
    {
        return $"Komik: {Judul} ({Tahun}), penulis {Penulis}";
    }
}

class MajalahAnak : Majalah
{
    public MajalahAnak(string judul, int tahun, int edisi)
        : base(judul, tahun, edisi)
    {
    }

    public string KategoriAnak()
    {
        return $"{Judul} adalah majalah anak.";
    }

    public override string Deskripsi()
    {
        return $"Majalah Anak: {Judul} ({Tahun}), edisi {Edisi}";
    }
}

class MajalahTeknologi : Majalah
{
    public MajalahTeknologi(string judul, int tahun, int edisi)
        : base(judul, tahun, edisi)
    {
    }

    public string TopikTeknologi()
    {
        return $"{Judul} membahas teknologi.";
    }

    public override string Deskripsi()
    {
        return $"Majalah Teknologi: {Judul} ({Tahun}), edisi {Edisi}";
    }
}

class Perpustakaan
{
    public List<Item> daftarItem = new List<Item>();

    public void TambahItem(Item item)
    {
        daftarItem.Add(item);
    }

    public void DaftarItem()
    {
        foreach (Item item in daftarItem)
        {
            item.InfoItem();
        }
    }
}

class Program
{
    static void Main()
    {
        Perpustakaan perpustakaan = new Perpustakaan();

        Novel novelUtama = new Novel(
            "Laut Bercerita",
            2017,
            "Leila S. Chudori",
            "Sep Berfokus pada kisah Biru Laut, seorang aktivis mahasiswa yang diculik dan disiksa " +
            "pada masa pergolakan politik tahun 1998. Novel ini menggambarkan penderitaan para korban " +
            "penculikan serta perjuangan keluarga yang ditinggalkan dalam mencari kebenaran dan keadilan.");

        Komik komikUtama = new Komik("Detective Conan", 1994, "Gosho Aoyama");
        MajalahAnak bobo = new MajalahAnak("Bobo", 1973, 12);
        MajalahAnak donalBebek = new MajalahAnak("Donal Bebek", 1979, 7);
        MajalahTeknologi wired = new MajalahTeknologi("Wired", 1993, 8);
        MajalahTeknologi pcMagazine = new MajalahTeknologi("Machine Magazine", 1984, 3);

        perpustakaan.TambahItem(novelUtama);
        perpustakaan.TambahItem(komikUtama);
        perpustakaan.TambahItem(bobo);
        perpustakaan.TambahItem(donalBebek);
        perpustakaan.TambahItem(wired);
        perpustakaan.TambahItem(pcMagazine);

        Console.WriteLine("=== DAFTAR ITEM PERPUSTAKAAN ===");
        perpustakaan.DaftarItem();

        Console.WriteLine();
        Console.WriteLine("=== POLIMORFISME ===");
        foreach (Item item in perpustakaan.daftarItem)
        {
            Console.WriteLine(item.Deskripsi());
        }

        Console.WriteLine();
        Console.WriteLine("=== METHOD KHUSUS ITEM ===");
        foreach (Item item in perpustakaan.daftarItem)
        {
            if (item is Novel itemNovel)
            {
                Console.WriteLine(itemNovel.BacaSinopsis());
                Console.WriteLine(itemNovel.CekPenulis());
            }
            else if (item is Komik itemKomik)
            {
                Console.WriteLine(itemKomik.TampilkanIlustrasi());
                Console.WriteLine(itemKomik.CekPenulis());
            }
            else if (item is MajalahAnak itemMajalahAnak)
            {
                Console.WriteLine(itemMajalahAnak.KategoriAnak());
                Console.WriteLine(itemMajalahAnak.InfoEdisi());
            }
            else if (item is MajalahTeknologi itemMajalahTeknologi)
            {
                Console.WriteLine(itemMajalahTeknologi.TopikTeknologi());
                Console.WriteLine(itemMajalahTeknologi.InfoEdisi());
            }
        }
    }
}

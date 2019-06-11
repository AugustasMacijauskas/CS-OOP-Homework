using System;

class Autorius : IComparable<Autorius>
{
	public string VardasPavarde() => vardasPav;
	private string vardasPav;

	public string KnygosPavadinimas() => knygosPavadinimas;
	private string knygosPavadinimas;

	public string Leidykla() => leidykla;
	private string leidykla;

	public double Kaina() => kaina;
	private double kaina;


	public Autorius(string vp, string pav, string leid, double kaina)
	{
		this.vardasPav = vp;
		this.knygosPavadinimas = pav;
		this.leidykla = leid;
		this.kaina = kaina;
	}

	public static bool operator <=(Autorius a1, Autorius a2)
	{
		int poz = String.Compare(a1.VardasPavarde(), a2.VardasPavarde(), StringComparison.CurrentCulture);

		return (a1.Kaina() < a2.Kaina()) || (Math.Abs(a1.Kaina() - a2.Kaina()) < 0.0001 && poz > 0);
	}

	public static bool operator >=(Autorius a1, Autorius a2)
	{
		int poz = String.Compare(a1.VardasPavarde(), a2.VardasPavarde(), StringComparison.CurrentCulture);

		return (a1.Kaina() > a2.Kaina()) || (Math.Abs(a1.Kaina() - a2.Kaina()) < 0.0001 && poz < 0);
	}

	public override string ToString() => $"|{vardasPav,20}|{knygosPavadinimas,15}|{leidykla,15}|{kaina,6:f3}|";

	public int CompareTo(Autorius other) => this.kaina.CompareTo(other.kaina);
}
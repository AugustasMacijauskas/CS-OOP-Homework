class Mazgas
{
	public Autorius Duomenys { get; set; }
	public Mazgas Kitas { get; set; }

	public Mazgas() { }

	public Mazgas(Autorius duom, Mazgas kit)
	{
		this.Duomenys = duom;
		this.Kitas = kit;
	}

	public Mazgas(Mazgas kit)
	{
		// Nors ir default;
		this.Duomenys = null;
		this.Kitas = kit;
	}
}
using System;
using System.Collections.Generic;
using Nunit;

public class JaratKezeloTests
{
    [Fact]
    public void UjJarat_HozzaadEgyUjJaratot()
    {
        var jaratKezelo = new JaratKezelo();
        jaratKezelo.UjJarat("AA123", "BUD", "JFK", new DateTime(2024, 6, 1, 12, 0, 0));

        var indulas = jaratKezelo.MikorIndul("AA123");

        Assert.Equal(new DateTime(2024, 6, 1, 12, 0, 0), indulas);
    }

    [Fact]
    public void Keses_HozzaadKeses()
    {
        var jaratKezelo = new JaratKezelo();
        jaratKezelo.UjJarat("AA123", "BUD", "JFK", new DateTime(2024, 6, 1, 12, 0, 0));
        jaratKezelo.Keses("AA123", 30);

        var indulas = jaratKezelo.MikorIndul("AA123");

        Assert.Equal(new DateTime(2024, 6, 1, 12, 30, 0), indulas);
    }

    [Fact]
    public void Keses_NegativKesesException()
    {
        var jaratKezelo = new JaratKezelo();
        jaratKezelo.UjJarat("AA123", "BUD", "JFK", new DateTime(2024, 6, 1, 12, 0, 0));

        var exception = Assert.Throws<ArgumentException>(() => jaratKezelo.Keses("AA123", -10));
        Assert.Equal("A késés nem lehet negatív.", exception.Message);
    }

    [Fact]
    public void JaratokRepuloterrol_VisszaadjaAJaratokListajat()
    {
        var jaratKezelo = new JaratKezelo();
        jaratKezelo.UjJarat("AA123", "BUD", "JFK", new DateTime(2024, 6, 1, 12, 0, 0));
        jaratKezelo.UjJarat("AA124", "BUD", "LAX", new DateTime(2024, 6, 1, 13, 0, 0));

        var jaratok = jaratKezelo.JaratokRepuloterrol("BUD");

        Assert.Contains("AA123", jaratok);
        Assert.Contains("AA124", jaratok);
    }

    [Fact]
    public void UjJarat_DuplikaltJaratSzam()
    {
        var jaratKezelo = new JaratKezelo();
        jaratKezelo.UjJarat("AA123", "BUD", "JFK", new DateTime(2024, 6, 1, 12, 0, 0));

        var exception = Assert.Throws<ArgumentException>(() => jaratKezelo.UjJarat("AA123", "BUD", "LAX", new DateTime(2024, 6, 1, 13, 0, 0)));
        Assert.Equal("Már létezik ilyen járatszám.", exception.Message);
    }
}


using System.Runtime.CompilerServices;

namespace DLS_OLA_A2.Objects;

public class ChemicalBarrel
{
    
    public int Id{ get; set; } // Primary key
    public string Chemical{ get; set; }
    
    public Job? Job{ get; set; }
    
    public Warehouse? Warehouse{ get; set; }
    
    
    public ChemicalBarrel()
    {
    }
    public ChemicalBarrel(int id, string chemical)
    {
        this.Id = id;
        this.Chemical = chemical;
    }
    
    public ChemicalBarrel(string chemical)
    {
        this.Chemical = chemical;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUR_CSTG.Data
{
    public enum Position
    {
        Pracownik_SUR = 1,
        Mistrz = 2,
        Kierownik = 3,
        Pracownik = 0,
        Admin = 4,
        Prezes = 5
    }

    public enum PartType
    {
        Automatyka = 1,
        Elektryka = 2,
        Mechanika = 3
    }

    public enum Unit
    {
        szt = 1,
        kg = 2,
        m = 3
    }

    public enum StatusBreakdown
    {
        Zgłoszona = 1,
        Oczekująca = 2,
        Usuwana = 3,
        Usunięta = 4
    }

    public enum BreakedownType
    {
        Automatczna = 1,
        Elektryczna = 2,
        Mechaniczna = 3
    }
}

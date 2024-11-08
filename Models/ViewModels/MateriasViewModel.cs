namespace Programacion_Unidad_2.Models.ViewModels
{
    public class CarreraViewModel
    {
        public string Carrera { get; set; }
        public string Programa { get; set; }
        public int CreditosTotales { get; set; }
        public List<SemestreView> Semestres { get; set; }
    }

    public class SemestreView
    {
        public int NumSemestre { get; set; }
        public List<MateriaView> Materias { get; set; }
    }

    public class MateriaView
    {
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public int Creditos { get; set; }
        public int Practica { get; set; }
        public int Teoria { get; set; }
    }
}

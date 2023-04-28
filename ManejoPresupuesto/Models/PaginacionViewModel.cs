namespace ManejoPresupuesto.Models
{
    public class PaginacionViewModel
    {
        public int Pagina { get; set; } = 1;
        public int recordsPorPagina = 10;
        private readonly int _cantidadMaximaRecordsPorPagina = 50;

        public int RecordsPorPagina
        {
            get
            {
                return recordsPorPagina;
            }
            set
            {
                recordsPorPagina = (value > _cantidadMaximaRecordsPorPagina) ? _cantidadMaximaRecordsPorPagina : value;
            }
        }

        public int RecordsAsaltar => recordsPorPagina * (Pagina-1);  
    }
}

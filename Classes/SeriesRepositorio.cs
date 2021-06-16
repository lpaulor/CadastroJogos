using System;
using System.Collections.Generic;
using Series.interfaces;

namespace Series
{
    public class SeriesRepositorio : iRepositorio<Series>
    {
        private List<Series> listaSerie = new List<Series>();
		public void Atualiza(int id, Series objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Series objeto)
		{
			listaSerie.Add(objeto);
		}

        public List<Series> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Series RetornaPorId(int Id)
        {
            return listaSerie[Id];
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using DesafioLike.Dominio.Entidades;
using DesafioLike.Dominio.IRepositorios;
using DesafioLike.Repositorio.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioLike.Repositorio.Repositorios
{
    public class PerguntaRepositorio : BaseRepositorio<Pergunta>, IPerguntaRepositorio
    {
        public PerguntaRepositorio(DataContext dataContext) : base(dataContext)
        {
            
        }

        ///Buscar todas as Perguntas incluindo as Categorias
        public async Task<Pergunta[]>GetAllPerguntaAsync(){

            IQueryable<Pergunta> query = DataContext.Perguntas.Include(a => a.Respostas).Include(a => a.Categoria);
            query = query.AsNoTracking().OrderByDescending(x => x.Descricao);
            
            return await query.ToArrayAsync(); 
        }

        public async Task<Pergunta[]> ObterPorPerguntaId(int perguntaId)
        {
            IQueryable<Pergunta> query = DataContext.Perguntas.Include(a => a.Respostas).Include(a => a.Categoria);
            query = query.AsNoTracking().OrderByDescending(x => x.Descricao).Where(x => x.Id == perguntaId);
            
            return await query.ToArrayAsync(); 
        }

        public async Task<Pergunta[]> ObterPorCategoriaId(int categoriaId)
        {
            IQueryable<Pergunta> query = DataContext.Perguntas.Include(a => a.Respostas).Include(a => a.Categoria);
            query = query.AsNoTracking().OrderByDescending(x => x.Descricao).Where(x => x.CategoriaId == categoriaId);
            
            return await query.ToArrayAsync(); 
        }
    }
    
}
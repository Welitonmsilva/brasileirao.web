using Brasileirao.web.Models.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.Repository
{
    public class Repository : IRepository
    {

        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void AddCalssificacao(Classificacao classificacao)
        {
            _context.Calssificacaoes.Add(classificacao);
        }

        public void AddCampo(Campo campo)
        {
            _context.Campos.Add(campo);
        }

        public void AddCidade(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
        }

        public void AddClube(Clube clube)
        {
            _context.Clubes.Add(clube);

        }

        public void AddJogador(Jogador jogador)
        {
            _context.Jogadores.Add(jogador);

        }

        public void AddJogo(Jogo jogo)
        {
            _context.Jogos.Add(jogo);

        }

        public void AddTreinador(Treinador treinador)
        {
            _context.Treinadores.Add(treinador);

        }

        public bool CampoExists(int Id)
        {
            return _context.Campos.Any(p => p.Id == Id);
        }

        public bool CidadeExists(int Id)
        {
            return _context.Cidades.Any(p => p.Id == Id);
        }

        public bool ClassificacaoExists(int Id)
        {
            return _context.Calssificacaoes.Any(p => p.Id == Id);
        }

        public bool ClubeExists(int Id)
        {
            return _context.Clubes.Any(p => p.Id == Id);
        }

        public Campo GetCampo(int id)
        {
            return _context.Campos.Find(id);
        }

        public IEnumerable<Campo> GetCampo()
        {
            return _context.Campos.OrderBy(p => p.Cidade);
        }

        public Cidade GetCidade(int id)
        {
            return _context.Cidades.Find(id);
        }
        //retorna todos os produtos
        public IEnumerable<Cidade> GetCidade()
        {
            return _context.Cidades.OrderBy(p => p.nome);
        }

        public Classificacao GetClassificacao(int id)
        {
            return _context.Calssificacaoes.Find(id);
        }

        public IEnumerable<Classificacao> GetClassificacao()
        {
            return _context.Calssificacaoes.OrderBy(p => p.D);
            return _context.Calssificacaoes.OrderBy(p => p.E);
            return _context.Calssificacaoes.OrderBy(p => p.GM);
            return _context.Calssificacaoes.OrderBy(p => p.GS);
            return _context.Calssificacaoes.OrderBy(p => p.J);
            return _context.Calssificacaoes.OrderBy(p => p.Posicao);
            return _context.Calssificacaoes.OrderBy(p => p.V);
            return _context.Calssificacaoes.OrderBy(p => p.Pts);

        }

        public Clube GetClube(int id)
        {
            return _context.Clubes.Find(id);
        }

        public IEnumerable<Clube> GetClube()
        {
            throw new NotImplementedException();
        }

        public Jogador GetJogador(int id)
        {
            return _context.Jogadores.Find(id);
        }

        public IEnumerable<Jogador> GetJogador()
        {
            throw new NotImplementedException();
        }

        public Jogo GetJogo(int id)
        {
            return _context.Jogos.Find(id);
        }

        public IEnumerable<Jogo> GetJogos()
        {
            throw new NotImplementedException();
        }

        public Treinador GetTreinador(int id)
        {
            return _context.Treinadores.Find(id);
        }

        public IEnumerable<Treinador> GetTreinador()
        {
            throw new NotImplementedException();
        }

        public bool JogadorExists(int Id)
        {
            throw new NotImplementedException();
        }

        public bool JogoExists(int Id)
        {
            throw new NotImplementedException();
        }

        public void RemoveCampo(Campo campo)
        {
            _context.Campos.Remove(campo);
        }

        public void RemoveCidade(Cidade cidade)
        {
            _context.Cidades.Remove(cidade);

        }

        public void RemoveClassificacao(Classificacao classificacao)
        {
            _context.Calssificacaoes .Remove(classificacao);

        }

        public void RemoveClube(Clube clube)
        {
            _context.Clubes.Remove(clube);

        }

        public void RemoveJogador(Jogador jogador)
        {
            _context.Jogadores.Remove(jogador);

        }

        public void RemoveJogo(Jogo jogo)
        {
            _context.Jogos.Remove(jogo);

        }

        public void RemoveTreinador(Treinador treinador)
        {
            _context.Treinadores .Remove(treinador);

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0; 
        }

        public bool TreinadorExists(int Id)
        {
            return _context.Treinadores.Any(p => p.Id == Id);
        }

        public void UpdateCampo(Campo campo)
        {
            _context.Campos.Update(campo);
        }

        public void UpdateCidade(Cidade cidade)
        {
            _context.Cidades.Update(cidade);

        }

        public void UpdateClassificacao(Classificacao classificacao)
        {
            _context.Calssificacaoes.Update(classificacao);

        }

        public void UpdateClube(Clube clube)
        {
            _context.Clubes.Update(clube);

        }

        public void UpdateJogador(Jogador jogador)
        {
            _context.Jogadores.Update(jogador);

        }

        public void UpdateJogo(Jogo jogo)
        {
            _context.Jogos .Update(jogo);

        }

        public void UpdateTreinador(Treinador treinador)
        {
            _context.Treinadores.Update(treinador);

        }
    }
}




using Brasileirao.web.Models.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.Repository
{
    public interface IRepository
    {

        void AddJogo(Jogo jogo);
        void AddClube(Clube clube);
        void AddCampo(Campo campo);
        void AddCalssificacao(Classificacao classificacao);
        void AddCidade(Cidade cidade);
        void AddJogador(Jogador jogador);
        void AddTreinador(Treinador treinador);
        

        Jogo GetJogo(int id);
        Clube GetClube(int id);
        Campo GetCampo(int id);
        Classificacao GetClassificacao(int id);
        Cidade GetCidade(int id);
        Treinador GetTreinador(int id);
        Jogador GetJogador(int id);


        IEnumerable<Jogo> GetJogos();
        IEnumerable<Clube> GetClube();
        IEnumerable<Campo> GetCampo();
        IEnumerable<Classificacao> GetClassificacao();
        IEnumerable<Cidade> GetCidade();
        IEnumerable<Jogador> GetJogador();
        IEnumerable<Treinador> GetTreinador();
        


        bool JogoExists(int Id);
        bool ClubeExists(int Id);
        bool CampoExists(int Id);
        bool ClassificacaoExists(int Id);
        bool CidadeExists(int Id);
        bool JogadorExists(int Id);
        bool TreinadorExists(int Id);


        void RemoveClube(Clube clube);
        void RemoveJogo(Jogo jogo);
        void RemoveCampo(Campo campo);
        void RemoveClassificacao(Classificacao classificacao);
        void RemoveCidade(Cidade cidade);
        void RemoveJogador(Jogador jogador);
        void RemoveTreinador(Treinador treinador);



        Task<bool> SaveAllAsync();


        void UpdateJogo(Jogo jogo);
        void UpdateClube(Clube clube);
        void UpdateCampo(Campo campo);
        void UpdateClassificacao(Classificacao classificacao);
        void UpdateCidade(Cidade cidade);
        void UpdateJogador(Jogador jogador);
        void UpdateTreinador(Treinador treinador);
    }
}

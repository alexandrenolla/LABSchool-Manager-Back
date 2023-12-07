using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.Enums
{
    public enum TipoAtividade
    {
        // Configuração do tema da aplicação
    AlteracaoNomeEmpresa = 1,
    AlteracaoSlogan = 2,
    AlteracaoPalhetaCores = 3,
    UploadLogotipo = 4,
    AlteracaoInformacoesMarca = 5,

    // Cadastro de usuários
    CadastroAdministrador = 6,
    CadastroPedagogo = 7,
    CadastroProfessor = 8,
    CadastroAluno = 9,

    // Edição de usuários
    EdicaoAdministrador = 10,
    EdicaoPedagogo = 11,
    EdicaoProfessor = 12,
    EdicaoAluno = 13,

    // Listagem de usuários
    ListagemAdministradores = 14,
    ListagemPedagogos = 15,
    ListagemProfessores = 16,
    ListagemAlunos = 17,

    // Deleção de usuários
    DelecaoAdministrador = 18,
    DelecaoPedagogo = 19,
    DelecaoProfessor = 20,
    DelecaoAluno = 21,

    // Atendimentos aos alunos
    RegistroAtendimentoPedagogo = 22,
    EdicaoAtendimentoPedagogo = 23,
    ListagemAtendimentosPedagogo = 24,
    DelecaoAtendimentoPedagogo = 25,

    // Listas de exercícios
    CriacaoListaExercicios = 26,
    EdicaoListaExercicios = 27,
    ListagemListasExercicios = 28,
    DelecaoListaExercicios = 29,

    // Avaliações fornecidas pelos professores
    RegistroAvaliacao = 30,
    EdicaoAvaliacao = 31,
    ListagemAvaliacoes = 32,
    DelecaoAvaliacao = 33,

    // Inativação
    InativacaoUsuario = 34,
    InativacaoRecurso = 35,

    // Logs
    AtendimentoRealizadoPedagogo = 36,
    ListaExerciciosAtualizada = 37

    }

}
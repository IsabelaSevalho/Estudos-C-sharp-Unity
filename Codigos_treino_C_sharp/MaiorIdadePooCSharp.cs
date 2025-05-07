/*Implemente um programa no qual o usuário deverá informar o nome e a idade de três pessoas.
O programa deverá informar o nome da pessoa que possuir a maior idade.

Regras que deverão ser seguidas para a implementação do algoritmo:

É obrigatório o uso de classe para representar uma pessoa e a mesma deverá possuir
como propriedades (características) um nome e uma idade. OK

A classe também deverá possuir um método chamado ExibirDados.
Esse método deverá exibir o nome e a idade da pessoa em questão. OK

Ao implementar a classe é obrigatório implementar dois construtores (Sobrecarga),
um que não recebe parâmetro algum e outro que irá receber o nome e a idade de uma pessoa.    OK*/

class Pessoa //sem o nível de acesso é automaticamente Internal - acessível por todas as classes do mesmo Assemble
{
    string nome;//sem o nível de acesso é automaticamente privado, acesso apenas por get e set
    int idade;

    public Pessoa(){}

    public Pessoa(string nome, int idade)
    {
        this.Nome = nome;
        this.Idade = idade;
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {this.nome}");
        Console.WriteLine($"Nome: {this.idade}");
    }

    //get e set
    public string Nome
    {
        get
        {
            return this.nome;
        }

        set
        {
            this.nome = value; //pega o valor atribuído
        }
    }

    public int Idade
    {
        get
        {
            return this.idade;
        }

        set
        {
            this.idade = value;
        }
    }
}

class Programa
{
    public static void Main(string[] args)
    {
        Pessoa[] listaPessoas = new Pessoa[3]; //criando vetor

        for(int i=0;i<3;i++)
        {
            Pessoa pessoa = new Pessoa();
            Console.WriteLine($"Digite o nome da pessoa {i+1}: ");
            string nome = Console.ReadLine(); //lendo o que foi escrito
            Console.WriteLine($"Digite o nome da pessoa {i+1}: ");
            int idade = Int32.Parse(Console.readLine());//convertendo a string para inteiro

            pessoa.Nome = nome;
            pessoa.Idade= idade;

            listaPessoas[i] = pessoa;
        }

        int maiorIdade = 0;
        string nomeMaiorIdade;

        foreach(Pessoa pessoa in listaPessoas)
        {
            if(pessoa.Idade>maiorIdade)
            {
                maiorIdade = pessoa.Idade;
                nomeMaiorIdade = pessoa.Nome;
            }
        }

        Console.WriteLine($"A pessoa com maior idade é {nomeMaiorIdade} com {maiorIdade} anos!");
    }
}
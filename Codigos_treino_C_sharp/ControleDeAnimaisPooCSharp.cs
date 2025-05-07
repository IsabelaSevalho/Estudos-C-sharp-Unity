/*Crie um algoritmo/programa no qual o usuário deverá informar o nome e
o tipo de cinco animais de estimação. O programa deverá exibir na tela para o usuário
quantos Cachorros, Gatos e peixes foram informados.

Regras que deverão ser seguidas para a implementação do algoritmo:

Os únicos tipos de animais válidos são Cachorro, Gato, Peixe. ok

Caso seja informado um tipo diferente o programa deverá definir o tipo do animal como Peixe. ok

É obrigatório criar uma classe para representar o Animal. ok

A classe deverá possuir dois dados privados (propriedades) para representar as características do animal. ok

A classe deverá possuir métodos de acesso para permitir que o usuário armazene/leia ok
os dados dos dois dados privados (propriedades).*/
using System;

class Animal
{
    string nome, tipo; //privado automaticamente

    public Animal(){}

    public Animal(string nome, string tipo)
    {
        this.Nome = nome;
        this.Tipo= tipo;
    }

    public void MostrarDados()
    {
        Console.WriteLine($"O animal {this.nome} eh um {this.tipo}");

    }

    public string Nome
    {
        get
        {
            return this.nome;
        }

        set
        {
            this.nome = value;
        }
    }

    public string Tipo
    {
        get
        {
            return this.tipo;
        }

        set
        {
            if(value!="Cachorro" && value!="Gato" && value!="Peixe")
            {
                this.tipo = "Peixe";
            }
            else
            {
                this.tipo = value;
            }
        }
    }
}

class Programa
{
    public static void Main(string[] args)
    {
        Animal[] animais = new Animal[5];
        for(int i=0;i<5;i++)
        {
            Console.WriteLine($"Digite o nome do animal {i+1}");
            string nome = Console.ReadLine();
            Console.WriteLine($"Digite o tipo do animal {i+1}");
            string tipo = Console.ReadLine();
            animais[i] = new Animal(nome, tipo);
        }

        int contCachorros=0;
        int contGatos=0;
        int contPeixes =0;

        foreach(Animal animal in animais)
        {
            if(animal.Tipo =="Cachorro")
            {
                contCachorros+=1;
            }
            else if(animal.Tipo=="Gato")
            {
                contGatos+=1;
            }
            else
            {
                contPeixes+=1;
            }
        }

        Console.WriteLine($"Foram informados:\n{contCachorros} cachorros;\n{contGatos} gatos;\n{contPeixes} peixes.");
    }
}

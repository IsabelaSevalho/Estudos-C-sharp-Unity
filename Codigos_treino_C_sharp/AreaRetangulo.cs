/*Crie um programa que exiba para o usuário qual é a área de um retângulo. Para implementar esse programa você deverá seguir as seguintes regras:

O usuário deverá informar para o programa o valor da base e altura do retângulo/quadrado.
É obrigatório criar/utilizar uma classe para representar o retângulo/quadrado.
A base e a altura informada pelo usuário deveram ser representadas na classe como propriedades.
O objeto deverá possuir uma propriedade para exibir o valor da área do retângulo/quadrado
O objeto deverá possuir um método que exiba os dados de todas as suas propriedades.*/

using System;

class Figura
{
    float baseQ, alturaQ; //automaticamente privado
    
    public Figura() { }

    public Figura(float baseQ, float alturaQ)
    {
        this.baseQ = baseQ;
        this.alturaQ = alturaQ;
    }

    public float Area()
    {
        return baseQ * alturaQ;
    }

    public void MostrarDados()
    {
        Console.WriteLine($"A base eh: {this.BaseQ}\nA altura eh: {this.AlturaQ}");
    }

    public float BaseQ
    {
        get
        {
            return this.baseQ;
        }

        set
        {
            this.baseQ = value;
        }
    }

    public float AlturaQ
    {

        get
        {
            return this.alturaQ;
        }

        set
        {
            this.alturaQ = value;
        }
    }
}

class Programa
{
    public static void Main(string[] args)
    {
        Figura fig = new Figura();
        Console.WriteLine("Digite a base: ");
        fig.BaseQ = float.Parse(Console.ReadLine());
        Console.WriteLine("Digite a altura: ");
        fig.AlturaQ = float.Parse(Console.ReadLine());

        fig.MostrarDados();
        Console.WriteLine($"Sua área eh: {fig.Area()}"); 
    }
}


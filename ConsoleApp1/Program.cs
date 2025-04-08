using System;
using System.Linq;

class Program
{
    /// <summary>
    /// Punkt wejścia do programu. Wczytuje dane od użytkownika, przetwarza je i wyświetla wynik.
    /// </summary>
    /// <param name="args">Argumenty wiersza poleceń (nieużywane w tym programie).</param>
    static void Main(string[] args)
    {
        // Wyświetlenie komunikatu zachęcającego użytkownika do wprowadzenia danych.
        Console.WriteLine("Podaj liczby do tablicy, oddzielając je spacjami:");
        string input = Console.ReadLine();

        // Sprawdzenie, czy użytkownik wprowadził dane.
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Nie podano żadnych liczb.");
            return; // Zakończenie programu, jeśli dane nie zostały podane.
        }

        int[] nums;
        try
        {
            //// Dla każdego elementu tablicy wynikowej z Split (czyli ciągu znaków),
            // wywołuje metodę int.Parse, która konwertuje ciąg znaków na liczbę całkowitą.
            // Przykład: Dla tablicy ["2", "3", "-1", "8", "4"] wynik będzie: [2, 3, -1, 8, 4]
            nums = input.Split(' ').Select(int.Parse).ToArray();

            nums = input.Split(' ').Select(int.Parse).ToArray();
        }
        catch (FormatException)
        {
            // Obsługa błędu w przypadku, gdy dane wejściowe nie są liczbami całkowitymi.
            Console.WriteLine("Podano nieprawidłowe dane. Upewnij się, że wprowadzasz liczby całkowite oddzielone spacjami.");
            return; // Zakończenie programu w przypadku błędu.
        }

        // Wywołanie metody obliczającej indeks równowagi.
        int equilibriumIndex = FindEquilibriumIndex(nums);

        // Wyświetlenie wyniku w zależności od tego, czy znaleziono indeks równowagi.
        if (equilibriumIndex != -1)
        {
            Console.WriteLine($"Znaleziono indeks równowagi: {equilibriumIndex}");
        }
        else
        {
            Console.WriteLine("Nie znaleziono indeksu równowagi.");
        }
    }

    /// <summary>
    /// Znajduje indeks równowagi w tablicy, gdzie suma elementów po lewej stronie
    /// jest równa sumie elementów po prawej stronie.
    /// </summary>
    /// <param name="nums">Tablica liczb całkowitych.</param>
    /// <returns>
    /// Indeks równowagi, jeśli istnieje; w przeciwnym razie -1.
    /// </returns>
    static int FindEquilibriumIndex(int[] nums)
    {
        // Obliczenie sumy wszystkich elementów w tablicy.
        int totalSum = nums.Sum();
        int leftSum = 0; // Inicjalizacja sumy elementów po lewej stronie.

        // Iteracja przez wszystkie elementy tablicy.
        for (int i = 0; i < nums.Length; i++)
        {
            // Obliczenie sumy elementów po prawej stronie.
            int rightSum = totalSum - leftSum - nums[i];

            // Sprawdzenie, czy suma po lewej stronie jest równa sumie po prawej stronie.
            if (leftSum == rightSum)
            {
                return i; // Zwrócenie indeksu równowagi.
            }

            // Aktualizacja sumy elementów po lewej stronie.
            leftSum += nums[i];
        }

        return -1; // Zwrócenie -1, jeśli nie znaleziono indeksu równowagi.
    }
}

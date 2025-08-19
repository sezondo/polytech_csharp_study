using CsharpStudy._2hakgi;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace CsharpStudy.Game.Tests;

[TestFixture]
[TestOf(typeof(Program01))]
public class Program01Test
{

    [Test]
    public void 테스트코드_01번문제()
    {
        Program01 programTest01 = new Program01();

        programTest01.word = "sadf";
        
        int arrayLength = programTest01.word.Length;
        
        //Console.WriteLine(arrayLength);
        
        for (int i = 0; i < arrayLength; i++)
        {
            if (programTest01.isVowel(i))
            {
                Assert.That(programTest01.isVowel(i),Is.EqualTo(true));
                Console.WriteLine(i + 1 + "번째 글자에서 모음 발견\n");
            }
        }
        
        Assert.That(programTest01.isConsonant(0), Is.EqualTo(true));
        
        
        
    }
    
    
}
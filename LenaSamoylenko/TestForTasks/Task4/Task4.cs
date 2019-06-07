using NUnit.Framework;
using CommonThings;
using Task4_ParserForFiles;
using System.Collections.Generic;
using System.IO;
using System;

namespace TestForTasks4
{
    [TestFixture]
    public class Task4
    {
        private static List<string> filesPath = new List<string>();
        private List<string> filesNames = new List<string>
        {
            "A_kak_luchshe_skazatb.txt",
            "Absoljutnoe_oruzhie_Ameriki.txt",
            "Aforizmy_i_mysli_ob_istorii.txt"
        };

        private List<string> firstRow = new List<string>
        {
            "Аннотация: В книге в популярной форме изложены важнейшие вопросы речевой культуры, связанные с нормативностью речи, ее благозвучием, выразительностью, а также словоупотреблением и оптимальным выбором конструкций.",
            "Аннотация: Тесла с легкостью шагнул на 100 лет вперед, спровоцировав самую главную (и, как показало время, самую кровавую) техническую революцию. Он изобрел индукционный мотор, лампы дневного света и беспроводную связь, думая, что работает во благо, – снаряды с дистанционным управлением, летательный аппарат вертикального взлета и лазерное оружие. Могущество его было столь велико, что даже падение Тунгусского метеорита до сих пор считается делом его рук. Тесла был уверен, что рентгеновские лучи можно использовать только в медицине, а при желании мог расколоть Землю посредством резонанса…",
            "Аннотация: Василий Осипович Ключевский — выдающийся русский историк, академик, профессор Московского университета и Московской духовной академии, создатель научной школы — писал о событиях и фактах российской действительности увлекательно и доступно. Исторические портреты, дневники и афоризмы ученого — блестящего мастера слова — отражают его размышления о науке, жизни, человеческих достоинствах и недостатках."
        };

        [SetUp]
        public void Setup()
        {
            string _path = null;
            var _info = new DirectoryInfo(Directory.GetCurrentDirectory());
            char _separator = Path.DirectorySeparatorChar;

            for (int i = 0; i <= 2; i++)
            {
                _info = _info.Parent;
            }
            _path = String.Concat(_info.FullName, _separator, "Books", _separator);

            for (int i = 0; i < filesNames.Count; i++)
            {
                var thisPath = String.Concat(_path, filesNames[i]);
                filesPath.Add(thisPath);
            }

        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void IsValidToGetText(int number)
        {
            //arrange
            FounderRowInText founder = new CounterRowInText(null, null);

            //act
            string text = founder.GetText(filesPath[number]);
            string row = firstRow[number];

            ////assert
            StringAssert.StartsWith( row, text, "IsNotValidTextAfterGetText");
        }
    }
}
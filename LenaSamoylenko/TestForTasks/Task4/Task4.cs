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
            "���������: � ����� � ���������� ����� �������� ��������� ������� ������� ��������, ��������� � �������������� ����, �� ������������, ����������������, � ����� ������������������ � ����������� ������� �����������.",
            "���������: ����� � ��������� ������ �� 100 ��� ������, ������������� ����� ������� (�, ��� �������� �����, ����� ��������) ����������� ���������. �� ������� ������������ �����, ����� �������� ����� � ������������ �����, �����, ��� �������� �� �����,�� ������� � ������������� �����������, ����������� ������� ������������� ������ � �������� ������. ���������� ��� ���� ����� ������, ��� ���� ������� ����������� ��������� �� ��� ��� ��������� ����� ��� ���. ����� ��� ������, ��� ������������� ���� ����� ������������ ������ � ��������, � ��� ������� ��� ��������� ����� ����������� ����������",
            "���������: ������� �������� ���������� � ���������� ������� �������, ��������, ��������� ����������� ������������ � ���������� �������� ��������, ��������� ������� ����� � ����� � �������� � ������ ���������� ���������������� ������������ � ��������. ������������ ��������, �������� � �������� ������� � ���������� ������� ����� � �������� ��� ����������� � �����, �����, ������������ ������������ � �����������."
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
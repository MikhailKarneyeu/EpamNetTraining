using GenericBinaryTree;
using NUnit.Framework;
using StudentsTests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBinaryTreeTests
{
    public class BinaryTreeTests
    {
        private static readonly object[] _testsLists =
        {
            new object[]
            {
                new List<StudentsTest>
                {
                    new StudentsTest("Name1", "TestName1", Convert.ToDateTime("11.01.2020 12:12:00"), 6),
                    new StudentsTest("Name2", "TestName2", Convert.ToDateTime("01.02.2020 11:12:00"), 8),
                    new StudentsTest("Name3", "TestName3", Convert.ToDateTime("09.03.2020 12:11:00"), 3),
                }
            },
            new object[]
            {
                new List<StudentsTest>
                {
                    new StudentsTest("Name3", "TestName3", Convert.ToDateTime("09.03.2020 12:11:00"), 3),
                    new StudentsTest("Name1", "TestName1", Convert.ToDateTime("11.01.2020 12:12:00"), 6),
                    new StudentsTest("Name2", "TestName2", Convert.ToDateTime("01.02.2020 11:12:00"), 8),

                } 
            },
            new object[]
            {
                new List<StudentsTest>
                {
                    new StudentsTest("Name1", "TestName1", Convert.ToDateTime("11.01.2020 12:12:00"), 6),
                    new StudentsTest("Name3", "TestName3", Convert.ToDateTime("09.03.2020 12:11:00"), 3),
                    new StudentsTest("Name2", "TestName2", Convert.ToDateTime("01.02.2020 11:12:00"), 8),
                },
            }
        };

        private static readonly object[] _saveTestsLists =
{
            new object[]
            {
                new List<StudentsTest>
                {
                    new StudentsTest("Name1", "TestName1", Convert.ToDateTime("11.01.2020 12:12:00"), 6),
                    new StudentsTest("Name2", "TestName2", Convert.ToDateTime("01.02.2020 11:12:00"), 8),
                    new StudentsTest("Name5", "TestName5", Convert.ToDateTime("03.03.2020 12:14:00"), 7),
                    new StudentsTest("Name3", "TestName3", Convert.ToDateTime("09.02.2020 12:11:00"), 3),
                    new StudentsTest("Name4", "TestName4", Convert.ToDateTime("12.03.2020 12:18:00"), 5),
                }
            }
        };


        [Test,TestCaseSource(nameof(_testsLists))]
        public void Add_ValidStudentsTest_NodeAdded(List<StudentsTest> list)
        {
            //Arrange
            BinaryTree<StudentsTest> tree = new BinaryTree<StudentsTest>();
            for (int i = 0; i < list.Count - 1; i++)
            {
                tree.Add(list[i]);
            }
            //Act
            tree.Add(list[^1]);
            //Assert
            Assert.IsTrue(tree.Count == list.Count && tree.Contains(list[^1]));
        }

        [Test,TestCaseSource(nameof(_testsLists))]
        public void Clear_TreeCleared(List<StudentsTest> list)
        {
            //Arrange
            BinaryTree<StudentsTest> tree = new BinaryTree<StudentsTest>();
            for (int i = 0; i < list.Count; i++)
            {
                tree.Add(list[i]);
            }
            //Act
            tree.Clear();
            //Assert
            Assert.IsTrue(tree.Head == null && tree.Count == 0);
        }

        [Test, TestCaseSource(nameof(_testsLists))]
        public void Contains_ValidStudentsTest_ReturnTrue(List<StudentsTest> list)
        {
            //Arrange
            BinaryTree<StudentsTest> tree = new BinaryTree<StudentsTest>();
            for (int i = 0; i < list.Count; i++)
            {
                tree.Add(list[i]);
            }
            //Act
            bool result = tree.Contains(list[^1]);
            //Assert
            Assert.IsTrue(result);
        }

        [Test, TestCaseSource(nameof(_testsLists))]
        public void Contains_MissingStudentsTest_ReturnFalse(List<StudentsTest> list)
        {
            //Arrange
            BinaryTree<StudentsTest> tree = new BinaryTree<StudentsTest>();
            for (int i = 0; i < list.Count-1; i++)
            {
                tree.Add(list[i]);
            }
            //Act
            bool result = tree.Contains(list[^1]);
            //Assert
            Assert.IsFalse(result);
        }

        [Test, TestCaseSource(nameof(_testsLists))]
        public void Remove_ValidStudentsTest_ReturnTrueandElementRemoved(List<StudentsTest> list)
        {
            //Arrange
            BinaryTree<StudentsTest> tree = new BinaryTree<StudentsTest>();
            for (int i = 0; i < list.Count; i++)
            {
                tree.Add(list[i]);
            }
            //Act
            bool result = tree.Remove(list[^1]);
            bool searchResult = tree.Contains(list[^1]);
            //Assert
            Assert.IsTrue(result && !searchResult);
        }

        [Test, TestCaseSource(nameof(_testsLists))]
        public void ToList_ReturnTestsList(List<StudentsTest> list)
        {
            //Arrange
            BinaryTree<StudentsTest> tree = new BinaryTree<StudentsTest>();
            for (int i = 0; i < list.Count; i++)
            {
                tree.Add(list[i]);
            }
            list.Sort();
            //Act
            List<StudentsTest> result = tree.ToList();
            //Assert
            Assert.IsTrue(result.SequenceEqual(list));
        }

        [Test, TestCaseSource(nameof(_saveTestsLists))]
        public void SaveReadFromXmlFile_TreeSavedReaded(List<StudentsTest> list)
        {
            //Arrange
            BinaryTree<StudentsTest> tree = new BinaryTree<StudentsTest>();
            for (int i = 0; i < list.Count; i++)
            {
                tree.Add(list[i]);
            }
            list.Sort();
            tree.SaveToXmlFile("TestFile.xml");
            //Act
            tree.ReadFromXmlFile("TestFile.xml");
            //Assert
            Assert.IsTrue(tree.ToList().SequenceEqual(list));
        }
    }
}
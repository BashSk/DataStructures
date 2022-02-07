using DataStructures.LinkedList;
using System.Collections.Generic;
using Xunit;

namespace DataStructures.Tests
{
    public class LinkedListTests
    {
        [Fact]
        public void ListIsEmptyInitially()
        {
            // Arrange
            MyLinkedList<int> linkedList = new();

            // Act, Assert
            Assert.True(linkedList.IsEmpty());
        }

        [Fact]
        public void ListIsNotEmptyAfterAdditionOperation()
        {
            // Arrange.
            MyLinkedList<int> linkedList = new();
            linkedList.AddNodeAtBeginning(5);
            linkedList.AddNodeAtBeginning(10);

            // Act, Assert.
            Assert.False(linkedList.IsEmpty());

        }

        [Theory]
        [MemberData(nameof(TestTraverseData))]
        public void TraverseList(int value1, int value2, int value3, List<int> expectedResult)
        {
            // Arrange.
            MyLinkedList<int> linkedList = new();
            linkedList.AddNodeAtEnd(value1);
            linkedList.AddNodeAtEnd(value2);
            linkedList.AddNodeAtEnd(value3);

            // Act
            var actualResult = linkedList.Traverse();

            // Assert.
            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void AddNodeAtBeginning()
        {
            // Arrange.
            MyLinkedList<int> linkedList = new();
            linkedList.AddNodeAtBeginning(5);
            linkedList.AddNodeAtBeginning(10);
            var expectedResult = new List<int>() { 10, 5 };

            // Act
            var actualResult = linkedList.Traverse();

            // Assert.
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AddNodeAtEnd()
        {
            // Arrange.
            MyLinkedList<int> linkedList = new();
            linkedList.AddNodeAtBeginning(5);
            linkedList.AddNodeAtBeginning(10);
            linkedList.AddNodeAtEnd(100);
            var expectedResult = new List<int>() { 10, 5 , 100};

            // Act
            var actualResult = linkedList.Traverse();

            // Assert.
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(2,9)]
        public void AddNodeAtIndex(int index, int value)
        {
            // Arrange.
            MyLinkedList<int> linkedList = new();
            linkedList.AddNodeAtBeginning(5);
            linkedList.AddNodeAtBeginning(10);
            linkedList.AddNodeAtEnd(100);
            linkedList.AddNodeAtIndex(value, index);
            var expectedResult = new List<int>() { 10, 9, 5, 100 };

            // Act
            var actualResult = linkedList.Traverse();

            // Assert.
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void DeleteFirstNode()
        {
            // Arrange.
            MyLinkedList<int> linkedList = new();
            linkedList.AddNodeAtBeginning(5);
            linkedList.AddNodeAtBeginning(10);
            linkedList.AddNodeAtBeginning(15);
            var expectedResult = new List<int>() { 10, 5 };


            // Act
            linkedList.DeleteFirstNode();
            var actualResult = linkedList.Traverse();

            // Assert.
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void DeleteLastNode()
        {
            // Arrange.
            MyLinkedList<int> linkedList = new();
            linkedList.AddNodeAtBeginning(5);
            linkedList.AddNodeAtBeginning(10);
            linkedList.AddNodeAtBeginning(15);
            var expectedResult = new List<int>() {15, 10};


            // Act
            linkedList.DeleteLastNode();
            var actualResult = linkedList.Traverse();

            // Assert.
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void DeleteNodeAtIndex()
        {
            // Arrange.
            MyLinkedList<int> linkedList = new();
            linkedList.AddNodeAtBeginning(5);
            linkedList.AddNodeAtBeginning(10);
            linkedList.AddNodeAtBeginning(15);
            var expectedResult = new List<int>() { 15, 5 };


            // Act
            linkedList.DeleteNodeAtIndex(2);
            var actualResult = linkedList.Traverse();

            // Assert.
            Assert.Equal(expectedResult, actualResult);
        }


        [Theory]
        [InlineData(10, true)]
        [InlineData(200, false)]
        public void ElementExists(int value, bool expectedResult)
        {
            // Arrange.
            MyLinkedList<int> linkedList = new();
            linkedList.AddNodeAtBeginning(5);
            linkedList.AddNodeAtBeginning(10);
            linkedList.AddNodeAtBeginning(15);

            // Act
            var actualResult = linkedList.Exists(value);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ReverseListWithIteration()
        {
            // Arrange.
            MyLinkedList<int> linkedList = new();
            linkedList.AddNodeAtBeginning(20);
            linkedList.AddNodeAtBeginning(15);
            linkedList.AddNodeAtBeginning(10);
            linkedList.AddNodeAtBeginning(5);
            var expectedResult = new List<int>() { 20, 15, 10, 5 };


            // Act
            linkedList.ReverseWithIteration();
            var actualResult = linkedList.Traverse();

            // Assert.
            Assert.Equal(expectedResult, actualResult);
        }
        public static IEnumerable<object[]> TestTraverseData =>
            new List<object[]>
            {
            new object[] { 5, 10, 15, new List<int> { 5, 10, 15 } },
            };


    }
}
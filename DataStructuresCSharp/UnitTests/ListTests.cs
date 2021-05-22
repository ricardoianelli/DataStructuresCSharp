using System;
using Xunit;
using FluentAssertions;
using DataStructuresCSharp.DataStructures;

namespace UnitTests
{
    public class ListTests
    {
        [Fact]
        public void ConstructList_GivenAnParameterlessConstruction_ShouldConstructListObject()
        {
            var myList = new List<int>();
            myList.Length.Should().Be(0);
            myList.Size.Should().Be(0);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        public void ConstructList_GivenAnInitialSize_ShouldConstructListObjectWithSpecifiedSize(int size)
        {
            var myList = new List<int>(size);
            myList.Length.Should().Be(0);
            myList.Size.Should().Be(size);
        }
        
        [Fact]
        public void ConstructList_GivenAnInvalidInitialSize_ShouldThrowException()
        {
            Action action = () => new List<int>(-1);
            action.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void Add_GivenAnEmptyList_ShouldAddElementsCorrectlyToTheList()
        {
            var newNumber = 3;
            List<int> myList = new List<int>();
            myList.Add(newNumber);
            myList.Get(0).Should().Be(newNumber);
            myList.Length.Should().Be(1);
            myList.Size.Should().Be(1);
        }
        
        [Fact]
        public void Add_GivenAFullList_ShouldRaiseSizeAndAddElementsCorrectlyToTheList()
        {
            var newNumber = 3;
            var startElements = new int[] {1, 2};
            var expectedElements = new int[] {1, 2, 3};
            List<int> expected = new List<int>(expectedElements);
            List<int> myList = new List<int>(startElements);
            
            myList.Add(newNumber);
            
            myList.Should().BeEquivalentTo(expected);
            myList.Length.Should().Be(3);
            myList.Size.Should().Be(startElements.Length +1);
        }
        
        [Fact]
        public void AddAndGet_UsingBracketNotation_ShouldWork()
        {
            var newNumber = 4;
            var startElements = new int[] {1, 2};
            List<int> myList = new List<int>(startElements);
            
            myList[2] = newNumber;

            myList[0].Should().Be(1);
            myList[1].Should().Be(2);
            myList[2].Should().Be(4);
            myList.Length.Should().Be(3);
            myList.Size.Should().Be(startElements.Length +1);
        }
        
        [Fact]
        public void Insert_GivenAnIndexOnEndOfTheList_ShouldAddElementCorrectlyToTheList()
        {
            var newNumber = 3;
            var startElements = new int[] {1, 2};
            var expectedElements = new int[] {1, 2, 3};
            List<int> expected = new List<int>(expectedElements);
            List<int> myList = new List<int>(startElements);
            
            myList.Insert(1, newNumber);
            
            myList.Should().BeEquivalentTo(expected);
            myList.Length.Should().Be(3);
            myList.Size.Should().Be(startElements.Length +1);
        }
        
        [Fact]
        public void Insert_GivenAnIndexOnStartOfTheList_ShouldAddElementCorrectlyToTheList()
        {
            var newNumber = 3;
            var startElements = new int[] {1, 2};
            var expectedElements = new int[] {3, 1, 2};
            List<int> expected = new List<int>(expectedElements);
            List<int> myList = new List<int>(startElements);
            
            myList.Insert(0, newNumber);
            
            myList.Should().BeEquivalentTo(expected);
            myList.Length.Should().Be(3);
            myList.Size.Should().Be(startElements.Length +1);
        }
        
        [Fact]
        public void Insert_GivenAnIndexOnTheMiddleOfTheList_ShouldAddElementCorrectlyToTheList()
        {
            var newNumber = 5;
            var startElements = new int[] {1, 2, 3, 4};
            var expectedElements = new int[] {1, 2, 5, 3, 4};
            List<int> expected = new List<int>(expectedElements);
            List<int> myList = new List<int>(startElements);
            
            myList.Insert(2, newNumber);
            
            myList.Should().BeEquivalentTo(expected);
            myList.Length.Should().Be(expectedElements.Length);
            myList.Size.Should().Be(startElements.Length +1);
        }

        [Fact]
        public void Remove_GivenAValueContainedInTheList_ShouldRemoveItAndResize()
        {
            
        }
        
        [Fact]
        public void Remove_GivenAValueNotContainedInTheList_ShouldDoNothing()
        {
            
        }
        
        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        public void RemoveAt_GivenAnIndexOutsideListLength_ShouldThrowAnException(int index)
        {
            
        }
        
        [Fact]
        public void RemoveAt_GivenAValidIndex_ShouldRemoveAndResize()
        {
            
        }
    }
}
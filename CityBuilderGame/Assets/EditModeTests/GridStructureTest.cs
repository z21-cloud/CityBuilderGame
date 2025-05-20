using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridStructureTest
{
    GridStructure structure;
    [OneTimeSetUp]
    public void Init()
    {
        structure = new GridStructure(3, 100, 100);
    }

    #region GridPositionTests
    // A Test behaves as an ordinary method
    [Test]
    public void CalculateGridPositionPasses()
    {
        //Arrange
        Vector3 position = new Vector3(0, 0, 0);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        //Assert
        Assert.AreEqual(Vector3.zero, returnPosition);
    }

    [Test]
    public void CalculateGridPositionFloatPasses()
    {
        //Arrange
        Vector3 position = new Vector3(2.9f, 0, 2.9f);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        //Assert
        Assert.AreEqual(Vector3.zero, returnPosition);
    }

    [Test]
    public void CalculateGridPositionFails()
    {
        //Arrange
        Vector3 position = new Vector3(3.1f, 0, 0);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        //Assert
        Assert.AreNotEqual(Vector3.zero, returnPosition);
    }
    #endregion

    #region GridTests
    [Test]
    public void PlaceStructure303AndCheckIsTakenPasses()
    {
        Vector3 position = new Vector3(3, 0, 3);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        GameObject testGameObject = new GameObject("TestGameObject");
        structure.PlaceStructureOnTheGrid(testGameObject, position);
        //assert
        Assert.IsTrue(structure.IsCellTaken(position));
    }

    [Test]
    public void PlaceStructureMINAndCheckIsTakenPasses()
    {
        Vector3 position = new Vector3(0, 0, 0);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        GameObject testGameObject = new GameObject("TestGameObject");
        structure.PlaceStructureOnTheGrid(testGameObject, position);
        //assert
        Assert.IsTrue(structure.IsCellTaken(position));
    }

    [Test]
    public void PlaceStructureMAXAndCheckIsTakenPasses()
    {
        Vector3 position = new Vector3(297, 0, 297);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        GameObject testGameObject = new GameObject("TestGameObject");
        structure.PlaceStructureOnTheGrid(testGameObject, position);
        //assert
        Assert.IsTrue(structure.IsCellTaken(position));
    }

    [Test]
    public void PlaceStructure303AndCheckIsTakenNullObjectShouldBeFail()
    {
        Vector3 position = new Vector3(3, 0, 3);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        GameObject testGameObject = null;
        structure.PlaceStructureOnTheGrid(testGameObject, position);
        //assert
        Assert.IsFalse(structure.IsCellTaken(position));
    }

    [Test]
    public void PlaceStructure303AndCheckIsTakenIndexOutOfBoundsFail()
    {
        Vector3 position = new Vector3(303, 0, 303);
        //Act
        //assert
        Assert.Throws<IndexOutOfRangeException>(()=>structure.IsCellTaken(position));
    }
    #endregion
}

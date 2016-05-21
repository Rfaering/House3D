using System;
using Assets;
using UnityEngine;

public class Configuration : MonoBehaviour
{
    public GameObject[] windows;
    public GameObject houseDoor;
    public Material[] materials;

    public Door Door;
    private Door _door;

    public HouseMaterial HouseMaterial;
    private HouseMaterial _houseMaterial;

    public DoorMaterial DoorMaterial;
    private DoorMaterial _doorMaterial;

    public WindowColor WindowColor;
    private WindowColor _windowColor;

    public WindowCount WindowCount;
    private WindowCount _lastSelectedCount;

    // Use this for initialization
    public void Start()
    {
        SetNumberOfActiveWindows(0);
        _lastSelectedCount = WindowCount;
    }

    // Update is called once per frame
    public void Update()
    {
        if (_lastSelectedCount != WindowCount)
        {
            WindowCountChanged(WindowCount);
            _lastSelectedCount = WindowCount;
        }

        if (_door != Door)
        {
            DoorChanged(Door);
            _door = Door;
        }

        if (_houseMaterial != HouseMaterial)
        {
            HouseMaterialChanged(HouseMaterial);
            _houseMaterial = HouseMaterial;
        }

        if (_doorMaterial != DoorMaterial)
        {
            DoorMaterialChanged(DoorMaterial);
            _doorMaterial = DoorMaterial;
        }

        if (_windowColor != WindowColor)
        {
            WindowColorChanged(WindowColor);
            _windowColor = WindowColor;
        }
    }

    private void WindowColorChanged(WindowColor windowColor)
    {        
        if (windowColor == WindowColor.Blue)
        {
            ChangeAllGlassColors(Color.blue);
        }

        if (windowColor == WindowColor.Red)
        {
            ChangeAllGlassColors(Color.red);
        }

        if (windowColor == WindowColor.White)
        {
            ChangeAllGlassColors(Color.white);
        }
    }

    private void ChangeAllGlassColors(Color color)
    {
        var changeAllGlassColors = GetComponentsInChildren<ChangedGlassColor>(true);
        foreach (var item in changeAllGlassColors)
        {
            item.ChangeGlassColor(color);
        }
    }

    private void DoorMaterialChanged(DoorMaterial doorMaterial)
    {
        var renderer = houseDoor.transform.Find("Door")
            .GetComponent<Renderer>();

        if (doorMaterial == DoorMaterial.Wood)
        {
            renderer.material = materials[3];
        }
        if (doorMaterial == DoorMaterial.Metal)
        {
            renderer.material = materials[2];
        }
    }

    private void HouseMaterialChanged(HouseMaterial houseMaterial)
    {
        var renderer = transform.Find("Walls")
            .GetComponent<Renderer>();

        if (houseMaterial == HouseMaterial.Wood)
        {
            renderer.material = materials[0];
        }
        if (houseMaterial == HouseMaterial.Brick)
        {
            renderer.material = materials[1];
        }
        if (houseMaterial == HouseMaterial.Metal)
        {
            renderer.material = materials[2];
        }
    }

    public void WindowCountChanged(WindowCount value)
    {
        if (value == WindowCount.Zero)
        {
            SetNumberOfActiveWindows(0);
        }
        else if (value == WindowCount.One)
        {
            SetNumberOfActiveWindows(1);
        }
        else if (value == WindowCount.Two)
        {
            SetNumberOfActiveWindows(2);
        }
        else if (value == WindowCount.Three)
        {
            SetNumberOfActiveWindows(3);
        }
        else if (value == WindowCount.Four)
        {
            SetNumberOfActiveWindows(4);
        }
    }

    private void DoorChanged(Door door)
    {
        if (door == Door.One)
        {
            houseDoor.SetActive(true);
            houseDoor.GetComponent<Animator>().Play("StartAnimation");
        }
        else
        {
            houseDoor.SetActive(false);
        }

    }

    private void SetNumberOfActiveWindows(int untilIndex)
    {
        for (int i = 0; i < windows.Length; i++)
        {
            if (i < untilIndex)
            {
                if (!windows[i].activeSelf)
                {
                    windows[i].SetActive(true);
                    windows[i].GetComponent<Animator>().Play("StartAnimation");
                }
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }
}


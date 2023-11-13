using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] GameObject _tilePrefab;
    [SerializeField] GameObject _wallPrefab;
    [SerializeField] GameObject _doorwayXPrefab;
    [SerializeField] GameObject _doorwayYPrefab;
    [SerializeField] GameObject _corridorXPrefab;
    [SerializeField] GameObject _corridorYPrefab;
    [SerializeField] int doorPadding;
    private RoomNode _roomNode;

    public void CreateRoom(RoomNode roomNode)
    {
        _roomNode = roomNode;
        gameObject.name = _roomNode.RoomName;
        transform.position = new Vector3(_roomNode.RoomSize.center.x, _roomNode.RoomSize.center.y, 0);

        CreateTiles();
        CreateEdges();
        CreatePath();
    }

    private void CreateTiles()
    {
        RectInt room = _roomNode.RoomSize;
        int tileSize = 1;
        float tilePivot = 0.0f;

        for (int y = room.yMin; y < room.yMax; y += tileSize)
        {
            for (int x = room.xMin; x < room.xMax; x += tileSize)
            {
                GameObject instance = Instantiate(_tilePrefab, transform);
                instance.transform.position = new Vector3(x + tilePivot, y + tilePivot, 0);
                instance.transform.localScale = Vector3.one;
            }
        }
    }

    private void CreateEdges()
    {
        int wallSize = 1;
        RectInt size = _roomNode.RoomSize;
        int width = size.width;
        int height = size.height;

        int xPos = 0;
        int yPos = 0;

        //Top edge
        for (int i = 0; i < width + 2; i++)
        {
            xPos = size.xMin + (i-1) * wallSize;
            yPos = size.yMax;

            if (!CheckDoorPosition(xPos, yPos, isHorizontal: true))
            {
                CreateWall(xPos, yPos);
            }
        }

        //Bottom edge
        for (int i = 0; i < width + 2; i++)
        {
            xPos = size.xMin + (i-1) * wallSize;
            yPos = size.yMin-1;

            if (!CheckDoorPosition(xPos, yPos, isHorizontal: true))
            {
                CreateWall(xPos, yPos);
            }
        }

        //Left side edge
        for (int i = 0; i < height; i++)
        {
            xPos = size.xMin-1;
            yPos = size.yMin + i * wallSize;

            if (!CheckDoorPosition(xPos, yPos, isHorizontal: false))
            {
                CreateWall(xPos, yPos);
            }
        }

        //Right side edge
        for (int i = 0; i < height; i++)
        {
            xPos = size.xMax;
            yPos = size.yMin + i * wallSize;

            if (!CheckDoorPosition(xPos, yPos, isHorizontal: false))
            {
                CreateWall(xPos, yPos);
            }
        }
    }

    private bool CheckDoorPosition(int wallXPos, int wallYPos, bool isHorizontal)
    {
        for (int i = 0; i < _roomNode.DoorInfos.Count; i++)
        {
            Vector3 doorPos = _roomNode.DoorInfos[i]._doorPosition;
            int doorXMin, doorXMax, doorYMin, doorYMax;
            if (doorPadding%2==0)   //doorpadding이 짝수면 각 좌표 양수값 방향을 한칸 줄임
            {
                doorXMin = Mathf.CeilToInt(doorPos.x - doorPadding);
                doorXMax = Mathf.FloorToInt(doorPos.x + doorPadding-1);
                doorYMin = Mathf.CeilToInt(doorPos.y - doorPadding);
                doorYMax = Mathf.FloorToInt(doorPos.y + doorPadding-1);
            }
            else
            {
                doorXMin = Mathf.CeilToInt(doorPos.x - doorPadding);
                doorXMax = Mathf.FloorToInt(doorPos.x + doorPadding);
                doorYMin = Mathf.CeilToInt(doorPos.y - doorPadding);
                doorYMax = Mathf.FloorToInt(doorPos.y + doorPadding);
            }
            

            if (isHorizontal)
            {
                if ((doorXMin < wallXPos && wallXPos < doorXMax) && ((int)doorPos.y == wallYPos))
                {
                    return true;
                }
            }
            else
            {
                if ((doorYMin < wallYPos && wallYPos < doorYMax) && ((int)doorPos.x == wallXPos))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void CreateWall(int xPos, int yPos)
    {
        GameObject instance = Instantiate(_wallPrefab, transform);
        instance.transform.position = new Vector3(xPos, yPos,0);
        instance.transform.localScale = Vector3.one;
    }

    private void CreatePath()
    {
        bool isX = true;
        GameObject corridorInstance;
        GameObject doorInstance;
        foreach (DoorInfo doorInfo in _roomNode.DoorInfos)
        {
            if (doorInfo.isX)
            {
                doorInstance = Instantiate(_doorwayXPrefab, transform);
            }
            else
            {
                doorInstance = Instantiate(_doorwayYPrefab, transform);
            }
            //복도 문 생성
            doorInstance.gameObject.name = doorInfo._name;
            doorInstance.transform.position = doorInfo._doorPosition;
            doorInstance.transform.localScale = Vector3.one;

            if (doorInfo._hasCorridor)
            {
                Vector3 newPos = doorInfo._doorPosition;
                for (int i = 0; i < doorInfo._corridorLength; i++)
                {
                    switch (doorInfo._doorDirection)
                    {
                        case eRelativeRectDirection.LEFT:
                            newPos.x -= 1;
                            isX = true;
                            break;
                        case eRelativeRectDirection.RIGHT:
                            newPos.x += 1;
                            isX = true;
                            break;
                        case eRelativeRectDirection.DOWN:
                            newPos.y -= 1;
                            isX = false;
                            break;
                        case eRelativeRectDirection.UP:
                            newPos.y += 1;
                            isX = false;
                            break;
                        case eRelativeRectDirection.NONE:
                        default:
                            break;
                    }
                    if (isX)
                    {
                        corridorInstance = Instantiate(_corridorXPrefab, transform);
                    }
                    else
                    {
                        corridorInstance = Instantiate(_corridorYPrefab, transform);
                    }
                    corridorInstance.transform.position = newPos;
                    corridorInstance.transform.localScale = Vector3.one;
                }
            }
        }
    }
}
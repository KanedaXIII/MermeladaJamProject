public class NoteInfo
{
    public int row;
    public char type;
    public float time;
    public NoteInfo(int row, float time, char type)
    {
        this.row = row;
        this.time = time;
        this.type = type;
    }
    public NoteInfo()
    {
        this.row = 0;
        this.time = 0;
        this.type = 'o';
    }
}

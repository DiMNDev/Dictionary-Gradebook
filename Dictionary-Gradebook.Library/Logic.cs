namespace Dictionary_Gradebook.Library;

public class Gradebook
{
    public Dictionary<int, string> Students { get; private set; }

    public Dictionary<int, double> Grades { get; private set; }

    public Gradebook()
    {
        Students = new();
        Grades = new();

    }

    public (bool success, string message) AddStudent(int id, string name, double grade)
    {
        Students.Add(id, name);
        Grades.Add(id, grade);
        return (true, $"{name} added successfully");
    }

    public (bool success, string message) UpdateStudent(int id, double grade)
    {
        if (Grades.ContainsKey(id))
        {
            Grades[id] = grade;
            return (true, $"{id} updated succesfully");
        }
        else
        {
            return (false, $"{id} not found");
        }
    }

    public (bool success, string message) RemoveStudent(int id)
    {
        if (Grades.ContainsKey(id))
        {
            Grades.Remove(id);
            return (true, $"{id} removed succesfully");
        }
        else
        {
            return (false, $"{id} not found");
        }
    }

    public (bool success, string name, double grade) FindStudent(int id)
    {
        if (Grades.ContainsKey(id))
        {
            return (true, Students[id], Grades[id]);
        }
        else
        {
            return (false, "not found", 0);
        }
    }

    public double AverageGrade()
    {
        int count = 0;
        double cumulative = 0;
        foreach (var (key, value) in Grades)
        {
            count++;
            cumulative += value;
        }

        cumulative = cumulative / count;

        return cumulative;
    }

    public (string name, double grade) HighestGrade()
    {
        double highestGrade = 0;
        string student = "";
        foreach (var (key, value) in Grades)
        {
            if (value > highestGrade)
            {
                highestGrade = value;
                student = Students[key];
            }
        }

        return (student, highestGrade);
    }

    public (string name, double grade) LowestGrade()
    {
        double lowestGrade = 150;
        string student = "";
        foreach (var (key, value) in Grades)
        {
            if (value < lowestGrade)
            {
                lowestGrade = value;
                student = Students[key];
            }
        }

        return (student, lowestGrade);
    }

}



/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model;

import java.util.ArrayList;

/**
 *
 * @author maiso
 */
public class StudentList {
    private ArrayList<Student> studentList = new ArrayList<>();

    
    public ArrayList<Student> filterStudentByCity(String city){
        ArrayList<Student> sameCityList = new ArrayList<>();
        for(Student s: studentList){
            if(s.getCity().getCityName().equals(city)){
                sameCityList.add(s);
            }
        }
        return sameCityList;
    }
    
    
    public Student filterStudentById(int id){
        Student result = null;
        for(Student s: studentList){
            if(s.getStudentId() == id){
                result = s;
                break;
            }
        }
        return result;
    }
    public ArrayList<Student> displayStudentList(){
        return studentList;
    }
    
    public void addStudent(Student s){
        studentList.add(s);
    }
    
    public void removeStudent(int id){
        for(Student s : studentList){
            if(s.getStudentId()==id){
                studentList.remove(s);
                break;
            }
        }
    }
    
    public boolean updateStudent(Student s){
        for(Student student: studentList){
            if(student.getStudentId() == s.getStudentId()){
                student.setStudentName(s.getStudentName());
                student.setCity(s.getCity());
                student.setDateOfBirth(s.getDateOfBirth());
                student.setSex(s.getSex());
                student.setSubject1(s.getSubject1());
                student.setSubject2(s.getSubject2());
                student.setSubject3(s.getSubject3());
                if(!s.getPhoto().isEmpty()){
                    student.setPhoto(s.getPhoto());
                }
                return true;
            }
        }
        return false;
    }
    
    public boolean containStudent(Student s){
        for(Student student : studentList){
            if(student.getStudentId() == s.getStudentId()){
                return true;
            }
        }
        return false;
    }
    
    
    
}

/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model;

import java.io.Serializable;

/**
 *
 * @author maiso
 */
public class Student implements Serializable{
    private int studentId;
    private String studentName;
    private City city;
    private String dateOfBirth;
    private String sex;
    private float subject1;
    private float subject2;
    private float subject3;
    private String photo;

    public Student(int studentId, String studentName, String sex, float subject1, float subject2, float subject3) {
        this.studentId = studentId;
        this.studentName = studentName;
        this.sex = sex;
        this.subject1 = subject1;
        this.subject2 = subject2;
        this.subject3 = subject3;
    }

    public Student(int studentId, String studentName, City city, String dateOfBirth, String sex, float subject1, float subject2, float subject3,String photo) {
        this.studentId = studentId;
        this.studentName = studentName;
        this.city = city;
        this.dateOfBirth = dateOfBirth;
        this.sex = sex;
        this.subject1 = subject1;
        this.subject2 = subject2;
        this.subject3 = subject3;
        this.photo = photo;
    }

    
    
    
    public int getStudentId() {
        return studentId;
    }

    public void setStudentId(int studentId) {
        this.studentId = studentId;
    }

    public String getStudentName() {
        return studentName;
    }

    public void setStudentName(String studentName) {
        this.studentName = studentName;
    }

    public City getCity() {
        return city;
    }

    public void setCity(City city) {
        this.city = city;
    }

    public String getDateOfBirth() {
        return dateOfBirth;
    }

    public void setDateOfBirth(String dateOfBirth) {
        this.dateOfBirth = dateOfBirth;
    }

    public String getSex() {
        return sex;
    }

    public void setSex(String sex) {
        this.sex = sex;
    }

    public float getSubject1() {
        return subject1;
    }

    public void setSubject1(float subject1) {
        this.subject1 = subject1;
    }

    public float getSubject2() {
        return subject2;
    }

    public void setSubject2(float subject2) {
        this.subject2 = subject2;
    }

    public float getSubject3() {
        return subject3;
    }

    public void setSubject3(float subject3) {
        this.subject3 = subject3;
    }

    public String getPhoto() {
        return photo;
    }

    public void setPhoto(String photo) {
        this.photo = photo;
    }
    
    
    
    
    @Override
    public String toString() {
        return "Student{" + "studentId=" + studentId + ", studentName=" + studentName + ", city=" + city + ", dateOfBirth=" + dateOfBirth + ", sex=" + sex + ", subject1=" + subject1 + ", subject2=" + subject2 + ", subject3=" + subject3 + '}';
    }
    
    
    
    
}

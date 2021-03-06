﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Tests.TestCases
    Class ConditionalStructureSameCondition_If
        Function Test() As Object
            If (someCondition1) Then
                DoSomething1()
            Else
                DoSomething1() ' Compliant, single line implementation is ignored
            End If

            If someCondition Then DoSomething1() Else DoSomething1() End ' Noncompliant
'                                                     ^^^^^^^^^^^^^^
            If someCondition Then DoSomething1() Else DoSomething2() : DoSomething1() End

            If (someCondition1) Then
                DoSomething1()
                DoSomething1()
            ElseIf (someCondition2) Then
                DoSomething1()
                DoSomething2()
            ElseIf (someCondition2) Then
                DoSomething1() ' Noncompliant {{Either merge this branch with the identical one on line 24 or change one of the implementations.}}
                DoSomething2()
            ElseIf (someCondition2) Then
                DoSomething1() ' Noncompliant {{Either merge this branch with the identical one on line 24 or change one of the implementations.}}
                DoSomething2()
            Else
                DoSomething1() ' Noncompliant {{Either merge this branch with the identical one on line 21 or change one of the implementations.}}
                DoSomething1()
            End If

            If (someCondition1) Then
                DoSomething1()
            ElseIf (someCondition2) Then
                DoSomething1() ' Compliant, single line
            Else
                DoSomething1() ' Compliant, single line
            End If

            If (someCondition1) Then
                DoSomething2()
                Return DoSomething1()
            ElseIf (someCondition2) Then
                DoSomething2()
                Return DoSomething1() ' Compliant, single line
            Else
                DoSomething2()
                Return DoSomething1() ' Compliant, single line
            End If
        End Function
    End Class
End Namespace

/*
 * Copyright (C) 2010 SonarSource SA
 * All rights reserved
 * mailto:contact AT sonarsource DOT com
 */
package com.sonar.csharp.parser.rules.classes;

import static com.sonar.sslr.test.parser.ParserMatchers.parse;
import static org.junit.Assert.assertThat;

import org.junit.Before;
import org.junit.Test;

import com.sonar.csharp.parser.CSharpGrammar;
import com.sonar.csharp.parser.CSharpParser;

public class ClassDeclarationTest {

  CSharpParser p = new CSharpParser();
  CSharpGrammar g = p.getGrammar();

  @Before
  public void init() {
    p.setRootRule(g.classDeclaration);
    g.attributes.mock();
    g.typeParameterList.mock();
    g.classBase.mock();
    g.typeParameterConstraintsClauses.mock();
    g.classBody.mock();
  }

  @Test
  public void testOk() {
    assertThat(p, parse("class MyClass classBody"));
    assertThat(p, parse("public class MyClass classBody;"));
    assertThat(p, parse("attributes partial class MyClass typeParameterList classBase typeParameterConstraintsClauses classBody"));
  }

}

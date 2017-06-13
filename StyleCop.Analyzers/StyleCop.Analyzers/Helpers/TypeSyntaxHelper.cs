﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Helpers
{
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using StyleCop.Analyzers.Lightup;

    internal static class TypeSyntaxHelper
    {
        public static bool IsReturnType(this TypeSyntax syntax)
        {
            switch (syntax.Parent.Kind())
            {
            case SyntaxKind.MethodDeclaration:
                return ((MethodDeclarationSyntax)syntax.Parent).ReturnType == syntax;

            case SyntaxKind.OperatorDeclaration:
                return ((OperatorDeclarationSyntax)syntax.Parent).ReturnType == syntax;

            case SyntaxKind.ConversionOperatorDeclaration:
                return ((ConversionOperatorDeclarationSyntax)syntax.Parent).Type == syntax;

            case SyntaxKind.PropertyDeclaration:
            case SyntaxKind.IndexerDeclaration:
            case SyntaxKind.EventDeclaration:
                return ((BasePropertyDeclarationSyntax)syntax.Parent).Type == syntax;

            case SyntaxKind.VariableDeclaration:
                return ((VariableDeclarationSyntax)syntax.Parent).Type == syntax;

            case SyntaxKindEx.LocalFunctionStatement:
                return ((LocalFunctionStatementSyntaxWrapper)syntax.Parent).ReturnType == syntax;

            default:
                return false;
            }
        }
    }
}
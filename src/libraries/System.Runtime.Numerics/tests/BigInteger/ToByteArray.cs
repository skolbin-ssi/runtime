﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Xunit;

namespace System.Numerics.Tests
{
    public partial class ExtractBytesMembersTests
    {
        // int => signed little endian byte representation
        // the matrix of unsigned / big-endian is built from this.
        public static IEnumerable<object[]> FromIntTests_MemberDataSeed()
        {
            yield return new object[] { 0, new byte[] { 0x00 } };
            yield return new object[] { 3, new byte[] { 0x03 } };
            yield return new object[] { 128, new byte[] { 0x80, 0x00 } };
            yield return new object[] { 200, new byte[] { 0xc8, 0x00 } };
            yield return new object[] { 256, new byte[] { 0x00, 0x01 } };
            yield return new object[] { 2005, new byte[] { 0xd5, 0x07 } };
            yield return new object[] { 10197, new byte[] { 0xd5, 0x27 } };
            yield return new object[] { 33023, new byte[] { 0xff, 0x80, 0x00 } };
            yield return new object[] { 2368349, new byte[] { 0x5d, 0x23, 0x24 } };
            yield return new object[] { 10756957, new byte[] { 0x5d, 0x23, 0xa4, 0x00 } };
            yield return new object[] { 193100307, new byte[] { 0x13, 0x7a, 0x82, 0x0b } };
            yield return new object[] { 1266842131, new byte[] { 0x13, 0x7a, 0x82, 0x4b } };
            yield return new object[] { int.MaxValue, new byte[] { 0xff, 0xff, 0xff, 0x7f } };
            yield return new object[] { -1, new byte[] { 0xff } };
            yield return new object[] { -128, new byte[] { 0x80 } };
            yield return new object[] { -172, new byte[] { 0x54, 0xff } };
            yield return new object[] { -23439, new byte[] { 0x71, 0xa4 } };
            yield return new object[] { -51301, new byte[] { 0x9b, 0x37, 0xff } };
            yield return new object[] { -126341, new byte[] { 0x7b, 0x12, 0xfe } };
            yield return new object[] { -13194515, new byte[] { 0xed, 0xaa, 0x36, 0xff } };
            yield return new object[] { -2068145902, new byte[] { 0x12, 0x99, 0xba, 0x84 } };
            yield return new object[] { int.MinValue, new byte[] { 0x00, 0x00, 0x00, 0x80 } };
        }

        [Theory]
        [MemberData(nameof(FromIntTests_MemberDataSeed))]
        public void ToByteArray_FromIntTests(int i, byte[] expectedBytes)
        {
            BigInteger bi = new BigInteger(i);
            byte[] bytes = bi.ToByteArray();
            Assert.Equal(expectedBytes, bytes);
            BigInteger bi2 = new BigInteger(bytes);
            Assert.Equal(bi, bi2);
        }

        // long => signed little endian byte representation
        // the matrix of unsigned / big-endian is built from this.
        public static IEnumerable<object[]> FromLongTests_MemberDataSeed()
        {
            yield return new object[] { 0x100112233L, new byte[] { 0x33, 0x22, 0x11, 0x00, 0x01 } };
            yield return new object[] { 0x300112233L, new byte[] { 0x33, 0x22, 0x11, 0x00, 0x03 } };
            yield return new object[] { 0x8000112233L, new byte[] { 0x33, 0x22, 0x11, 0x00, 0x80, 0x00 } };
            yield return new object[] { 0x3cd00112233L, new byte[] { 0x33, 0x22, 0x11, 0x00, 0xcd, 0x03 } };
            yield return new object[] { 0xf92100112233L, new byte[] { 0x33, 0x22, 0x11, 0x00, 0x21, 0xf9, 0x00 } };
            yield return new object[] { 0x749aa00112233L, new byte[] { 0x33, 0x22, 0x11, 0x00, 0xaa, 0x49, 0x07 } };
            yield return new object[] { 0x80112200112233L, new byte[] { 0x33, 0x22, 0x11, 0x00, 0x22, 0x11, 0x80, 0x00 } };
            yield return new object[] { 0x7654321000112233L, new byte[] { 0x33, 0x22, 0x11, 0x00, 0x10, 0x32, 0x54, 0x76 } };
            yield return new object[] { long.MaxValue, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f } };
            yield return new object[] { -0x100112233L, new byte[] { 0xcd, 0xdd, 0xee, 0xff, 0xfe } };
            yield return new object[] { -0x8000112233L, new byte[] { 0xcd, 0xdd, 0xee, 0xff, 0x7f, 0xff } };
            yield return new object[] { -0x3cd00112233L, new byte[] { 0xcd, 0xdd, 0xee, 0xff, 0x32, 0xfc } };
            yield return new object[] { -0xf92100112233L, new byte[] { 0xcd, 0xdd, 0xee, 0xff, 0xde, 0x06, 0xff } };
            yield return new object[] { -0x749aa00112233L, new byte[] { 0xcd, 0xdd, 0xee, 0xff, 0x55, 0xb6, 0xf8 } };
            yield return new object[] { -0x80112200112233L, new byte[] { 0xcd, 0xdd, 0xee, 0xff, 0xdd, 0xee, 0x7f, 0xff } };
            yield return new object[] { -0x7654321000112233L, new byte[] { 0xcd, 0xdd, 0xee, 0xff, 0xef, 0xcd, 0xab, 0x89 } };
            yield return new object[] { long.MinValue, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 } };
            yield return new object[] { -0x100000000L, new byte[] { 0x00, 0x00, 0x00, 0x00, 0xff } };
            yield return new object[] { -0x300000000L, new byte[] { 0x00, 0x00, 0x00, 0x00, 0xfd } };
            yield return new object[] { -0x8000000000L, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x80 } };
            yield return new object[] { -0xfe00000000L, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x02, 0xff } };
            yield return new object[] { -0xff00000000L, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x01, 0xff } };
            yield return new object[] { -0xfeff00000000L, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0xff } };
            yield return new object[] { -0xffff00000000L, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0xff } };
            yield return new object[] { -0xfeffff00000000L, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0xff } };
            yield return new object[] { -0xffffff00000000L, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0xff } };
        }

        [Theory]
        [MemberData(nameof(FromLongTests_MemberDataSeed))]
        public void ToByteArray_FromLongTests(long l, byte[] expectedBytes)
        {
            BigInteger bi = new BigInteger(l);
            byte[] bytes = bi.ToByteArray();
            Assert.Equal(expectedBytes, bytes);
            BigInteger bi2 = new BigInteger(bytes);
            Assert.Equal(bi, bi2);
        }

        // string => signed big endian byte representation
        // the matrix of unsigned / little-endian is built from this.
        public static IEnumerable<object[]> FromStringTests_MemberDataSeed()
        {
            yield return new object[] { "0", new byte[] { 0 } };
            yield return new object[] { "127", new byte[] { 0x7F } };
            yield return new object[] { "128", new byte[] { 0x00, 0x80 } };
            yield return new object[] { "33022", new byte[] { 0x00, 0x80, 0xFE } };
            yield return new object[] { "-32514", new byte[] { 0x80, 0xFE } };
            yield return new object[] { "-18374686475376656384", new byte[] { 0xff, 0x01, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 } };
            yield return new object[] { "-18446744069414584320", new byte[] { 0xff, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 } };
            yield return new object[] { "12364093636075302621581796971036731159910277399901099375861080574506898189967563102391591201943540153492149033597384108294298661111799425262742266671957323486506857011293831406641316917374615487590434666756862524718179898130435474398176187353530443750986128762955255137790631223519091107256083370837751230886741470719554141609004126665185940207631783192780186624919167901565253877397154522582982120840364212333366972597473045167409184762879376102731157263235904816835054250885637739932914015117504485702897712016943555929710070193511128651378003670520306509417025958556935067307123832592173743652726898616663215056178200135054604939862749863002480827458494339065850786495122398411385446068167146399066035389699059499954747263948595492570959736940353095030589033792026029085438901525807032848103038290802923997216273712349905230080849822000411239032166420681788646737098078876258256753058713515144604794792139863186822520361187685685356628044518258989638970651859178568755065879235553215218267011024902142765549091793970027321040036512883269922219608216030987714165823965404563131018846411947569009598716649463301689241563037584803938711917477764863093448004918315253652379776337794243677630540042379049027", new byte[] { 0x00, 0xf0, 0x1d, 0x7b, 0xa2, 0xfd, 0x50, 0xf9, 0x50, 0x07, 0xce, 0x2a, 0xdf, 0xfb, 0x75, 0x70, 0x49, 0x5e, 0x5d, 0xf7, 0x1b, 0x0a, 0x76, 0x1f, 0xe7, 0xe3, 0xc7, 0x0a, 0xc7, 0xee, 0xca, 0x4e, 0xa2, 0xe6, 0xae, 0xe8, 0x1a, 0x2c, 0x3b, 0xa9, 0x12, 0x77, 0xb1, 0x47, 0x3c, 0xb5, 0xab, 0x32, 0x26, 0x18, 0x0d, 0x43, 0x51, 0x6b, 0x11, 0x0c, 0x45, 0xed, 0x52, 0x7d, 0xce, 0xe8, 0x75, 0x6c, 0xe1, 0xda, 0xaf, 0x42, 0x1c, 0xc6, 0x21, 0x23, 0x1f, 0x5d, 0x2d, 0x48, 0xf8, 0x20, 0x67, 0x2f, 0x49, 0x3d, 0x3e, 0x5d, 0xc2, 0x53, 0xc8, 0xe0, 0x3d, 0xe2, 0xdc, 0x51, 0x2f, 0x44, 0xc9, 0x72, 0xb6, 0x04, 0xa0, 0x19, 0x1f, 0x03, 0xb9, 0x0f, 0x57, 0x80, 0x55, 0x41, 0x10, 0x7e, 0x7c, 0x78, 0xdc, 0xbb, 0x82, 0x6e, 0x6a, 0xd9, 0x0e, 0xac, 0x87, 0x0c, 0xfd, 0xc0, 0x79, 0xdf, 0xf5, 0x98, 0xfe, 0x9c, 0x58, 0xa9, 0x63, 0xc2, 0x99, 0x31, 0x09, 0x1c, 0x50, 0xcf, 0x03, 0x4f, 0x96, 0xef, 0x98, 0x56, 0x44, 0xc2, 0x0f, 0x63, 0x20, 0x19, 0x0b, 0x60, 0x28, 0x09, 0xb2, 0x3e, 0xe5, 0xe3, 0x91, 0xc2, 0x98, 0x3d, 0xc0, 0x81, 0x0b, 0x5a, 0xdd, 0x88, 0x6a, 0xc1, 0xff, 0x94, 0x7f, 0xe0, 0x96, 0x6b, 0x67, 0x75, 0x80, 0x53, 0xa1, 0x89, 0x14, 0x19, 0x59, 0xdc, 0x13, 0x67, 0x01, 0x7c, 0x64, 0xfe, 0xeb, 0x7b, 0x8c, 0x97, 0x2d, 0x1a, 0x90, 0x48, 0x4b, 0xea, 0x48, 0xc0, 0x77, 0x23, 0x68, 0x65, 0x19, 0xcf, 0xcf, 0x1c, 0x89, 0x93, 0xe0, 0xd2, 0xfd, 0x81, 0x6a, 0x6e, 0xd8, 0x76, 0xad, 0x65, 0xb5, 0xe0, 0xe1, 0xe2, 0x9c, 0x13, 0x70, 0x0e, 0x79, 0x1c, 0xaa, 0xac, 0x0d, 0x3f, 0x10, 0x4e, 0x47, 0x36, 0xb9, 0x23, 0xd3, 0x6a, 0x50, 0x9a, 0xe2, 0x83, 0x94, 0xf8, 0x1b, 0x41, 0x4c, 0x22, 0x92, 0x58, 0x9f, 0xc8, 0xad, 0x36, 0x51, 0x59, 0xa6, 0xbb, 0x86, 0x4f, 0x9d, 0x3a, 0x9f, 0x1d, 0x0b, 0x2e, 0x7f, 0xf8, 0x83, 0xfd, 0x1c, 0x3b, 0xe1, 0x3d, 0xb2, 0xdc, 0x13, 0x18, 0x71, 0xec, 0x63, 0xf3, 0xfc, 0x41, 0x6f, 0x14, 0xec, 0xcc, 0x7f, 0x28, 0xeb, 0x12, 0xc6, 0x4c, 0xa4, 0x92, 0x7f, 0x7a, 0x65, 0xcf, 0x8f, 0x63, 0x47, 0x3e, 0x4f, 0xeb, 0x03, 0x7b, 0x20, 0xf8, 0x01, 0xa2, 0x9d, 0xe2, 0x5f, 0x85, 0xfb, 0x7b, 0xdf, 0x10, 0x45, 0x2f, 0x6f, 0xb2, 0x6b, 0xff, 0x69, 0xf5, 0x64, 0x8e, 0x18, 0x71, 0x7a, 0x04, 0x31, 0xc3, 0xf8, 0xa0, 0x6c, 0x0f, 0x0a, 0x57, 0x83, 0x83, 0x58, 0xda, 0xaf, 0x99, 0xe6, 0x68, 0x13, 0xe8, 0x15, 0xbc, 0xd7, 0xef, 0xb2, 0x4b, 0x08, 0x18, 0x97, 0xb2, 0x77, 0x0c, 0xb5, 0x96, 0xdb, 0x21, 0x14, 0x39, 0x52, 0x9f, 0x83, 0x47, 0x96, 0xe8, 0x9f, 0x94, 0xe2, 0x73, 0x40, 0x02, 0x7f, 0xbd, 0xb9, 0x65, 0x6a, 0x33, 0x15, 0xb8, 0xc8, 0x9d, 0x12, 0xf9, 0x14, 0x04, 0x77, 0x56, 0xdc, 0x87, 0xd2, 0xca, 0xb2, 0x05, 0x99, 0xad, 0xa6, 0xd2, 0x81, 0x8f, 0x64, 0xcd, 0xe5, 0x70, 0x2c, 0xbf, 0xc0, 0xb6, 0xb7, 0xa8, 0x4a, 0x45, 0x6b, 0x98, 0x8f, 0x5b, 0xb8, 0x87, 0xf5, 0x64, 0xd1, 0x67, 0xd6, 0xdd, 0x76, 0x29, 0xf0, 0x77, 0x45, 0xfc, 0x27, 0xa4, 0x4a, 0xac, 0xaa, 0x1a, 0x90, 0xbe, 0xf8, 0x91, 0x50, 0x30, 0x6d, 0x73, 0x49, 0x3c, 0xab, 0xa4, 0xaf, 0x13, 0xa8, 0xdd, 0x0a, 0xf5, 0xc3, 0x34, 0x98, 0xb4, 0x7f, 0x0b, 0xb4, 0x63, 0x0f, 0xe3, 0x6e, 0xcc, 0xf8, 0x1d, 0xea, 0x34, 0x71, 0x8b, 0x06, 0xa5, 0x4f, 0x81, 0x12, 0xa9, 0xfd, 0xb8, 0x43 } };
            yield return new object[] { "-1500566381192798663042470094195709329888702572609999105286667163606153967917290138712408909178830809119008530236180974166477902167438722120032328817587204550920260039698718901932896233377293832747667996098291476468951412311792579258943277768740116090186686963715856483147820131067091322876669577393210366426487028489206389247040659375214497672166049911500383423054774768058254673393263777607084960848658501529675225559011863409579602879830226289200557853195239635009395081629845517655774307827048680743808664945667425540772434721298573889660136104342949269877806888346513652384111162522895043239369803590295673472600852282901495791087130835483730406094888840219829189061112151151001898468218215751327382511813082884657126285166508024920536549363279290734920537316417286759974845704859198588552892947264856714040130408613412473996518038227113385600353365608575770837750435553392852567153310861059766627383200108369176626042676222592985818614861742325706568951932845447397512345181981733524874445871904571909006536844113768514813826258460666950996534336842871477679076553532049073323784011247842133811527684859166963235747571306708361946012941167234981369225227878132777327321706825860067928644566542309248", new byte[] { 0xe2, 0xdb, 0xc3, 0xee, 0xdc, 0xd0, 0xa4, 0xdc, 0x41, 0xec, 0xf7, 0xf3, 0x53, 0x2f, 0xd9, 0x5e, 0xe5, 0xbf, 0x5e, 0xea, 0x84, 0xde, 0x00, 0x79, 0x48, 0xc6, 0xf4, 0xd0, 0x29, 0xd9, 0x41, 0xb3, 0xc1, 0x31, 0xe0, 0x18, 0x42, 0xa5, 0x76, 0x88, 0x95, 0x60, 0xe8, 0x55, 0x51, 0x98, 0x01, 0xdb, 0x58, 0x0f, 0x76, 0xe5, 0x23, 0xb3, 0xa3, 0x8b, 0xb6, 0x8b, 0x66, 0x30, 0xd2, 0xb4, 0x13, 0x44, 0xd7, 0xa1, 0x6f, 0xa1, 0xee, 0x41, 0xab, 0x87, 0x5b, 0x64, 0x53, 0x80, 0x1b, 0x1b, 0x15, 0xba, 0x7e, 0x19, 0xbd, 0xc5, 0x9e, 0xfa, 0x1e, 0x59, 0x19, 0x56, 0x59, 0x7e, 0xa3, 0x2d, 0x97, 0xc8, 0xd9, 0x9f, 0xd3, 0x9b, 0x43, 0x25, 0x31, 0x4b, 0x17, 0x5c, 0x5d, 0x95, 0xd2, 0x5a, 0x91, 0xca, 0x83, 0xe9, 0x16, 0x33, 0x10, 0x26, 0x65, 0x31, 0x79, 0xa3, 0xf7, 0x89, 0xd5, 0xe3, 0x8d, 0x45, 0x86, 0x2a, 0xc9, 0xd8, 0x40, 0x93, 0xd8, 0xbf, 0x6f, 0xfa, 0x13, 0xf5, 0x4a, 0x62, 0x15, 0xd9, 0x55, 0xd9, 0xf6, 0xcc, 0xc2, 0xdb, 0xbc, 0xce, 0x50, 0x7a, 0x45, 0xca, 0xca, 0x54, 0x20, 0x76, 0x8e, 0x26, 0x9a, 0x5d, 0x3b, 0x23, 0xad, 0x80, 0xa5, 0xae, 0x63, 0x27, 0x03, 0x10, 0x65, 0x06, 0x6e, 0x65, 0x38, 0x70, 0x10, 0xef, 0xfb, 0xbc, 0xcf, 0xf3, 0x3d, 0x0a, 0x40, 0xe7, 0xd3, 0x20, 0x5d, 0x4f, 0x84, 0xd8, 0xcb, 0xea, 0x65, 0x28, 0x26, 0x15, 0x54, 0x08, 0x77, 0x07, 0xd4, 0x21, 0xb4, 0x69, 0xc6, 0x70, 0x02, 0xd2, 0x5d, 0x4b, 0x7f, 0xf6, 0xb4, 0x11, 0x7d, 0x1b, 0x74, 0x59, 0x1f, 0x2d, 0x5d, 0x75, 0x5c, 0x1a, 0x6e, 0x78, 0xad, 0x12, 0x8d, 0x3b, 0x52, 0x0d, 0x4a, 0x9f, 0x28, 0x22, 0xc4, 0x36, 0xb3, 0xdf, 0xd5, 0xa3, 0xa3, 0xa7, 0x06, 0xea, 0x49, 0x16, 0x01, 0xc8, 0xb2, 0x27, 0xab, 0x04, 0xa2, 0x62, 0x93, 0xcb, 0xdc, 0xfe, 0x33, 0xe4, 0x31, 0x58, 0x7c, 0x08, 0x23, 0x4c, 0x88, 0x1e, 0x9f, 0xc9, 0x39, 0x46, 0xea, 0x7a, 0x69, 0xfa, 0xff, 0x38, 0x87, 0x6b, 0xde, 0x7c, 0x6b, 0xfa, 0x2f, 0x81, 0xff, 0xb1, 0x82, 0x34, 0x38, 0xb8, 0xd1, 0xbf, 0x68, 0x60, 0x07, 0x3d, 0x91, 0x4e, 0xb2, 0x02, 0x1a, 0x05, 0x70, 0xb7, 0x26, 0xbb, 0x95, 0xad, 0xfd, 0xcc, 0x52, 0x80, 0xf9, 0xda, 0x45, 0x04, 0x24, 0xc4, 0x8f, 0x46, 0x22, 0x9a, 0x0d, 0xa0, 0x88, 0x03, 0x54, 0x2d, 0x2f, 0x54, 0x1b, 0xf1, 0xe5, 0xfe, 0xa0, 0x6c, 0x70, 0x31, 0xb1, 0x36, 0x8b, 0xcf, 0x33, 0xf5, 0xc1, 0x77, 0x6c, 0x89, 0xa3, 0xb3, 0xd9, 0x66, 0x5d, 0xb8, 0x40, 0x66, 0xb3, 0x0d, 0xcd, 0x0c, 0xde, 0xd4, 0x6c, 0x55, 0x66, 0x95, 0x78, 0x7f, 0xc9, 0x0a, 0x8e, 0x41, 0x50, 0xc2, 0xe9, 0x88, 0x91, 0xce, 0x56, 0xa2, 0xc6, 0xc4, 0x87, 0xb0, 0x25, 0xc9, 0x74, 0xf6, 0x58, 0xbe, 0xde, 0xf9, 0xee, 0x37, 0x5c, 0xfe, 0x54, 0xc1, 0x68, 0x40, 0x64, 0x99, 0x66, 0x2e, 0x18, 0x6b, 0xa6, 0x0a, 0xfe, 0x13, 0xec, 0x1e, 0x6f, 0xf3, 0xa0, 0xc9, 0x17, 0x9b, 0x6e, 0x92, 0xf2, 0x42, 0xfb, 0xbd, 0xfb, 0x11, 0x53, 0x7c, 0xeb, 0xd4, 0xd2, 0x16, 0xaf, 0x20, 0x5e, 0x42, 0x09, 0xea, 0x92, 0x0b, 0xab, 0x94, 0xaa, 0xaf, 0x23, 0xda, 0xda, 0xe3, 0x40, 0xc1, 0x5a, 0xab, 0xc2, 0xdd, 0x8d, 0x76, 0x62, 0xb3, 0xd4, 0x13, 0xac, 0x0c, 0x06, 0xa9, 0x98, 0x27, 0xa8, 0x34, 0x94, 0xd6, 0x85, 0x99, 0x24, 0x7e, 0x8a, 0xf1, 0xf8, 0x6d, 0xef, 0x66, 0xf0, 0xe6, 0xc9, 0x2c, 0x4d, 0x1f, 0x3e, 0xfa, 0x28, 0x80 } };
        }

        [Theory]
        [MemberData(nameof(FromStringTests_MemberDataSeed))]
        public void ToByteArray_FromStringTests(string str, byte[] expectedBytes)
        {
            BigInteger bi = BigInteger.Parse(str);
            byte[] bytes = bi.ToByteArray();

            // The expected data is big endian, the export is little endian.
            // Since this method already owns the exported data array reverse it instead of the input.
            Array.Reverse(bytes);
            Assert.Equal(expectedBytes, bytes);

            // Now put it back.
            Array.Reverse(bytes);

            BigInteger bi2 = new BigInteger(bytes);
            Assert.Equal(bi, bi2);
        }

        public static IEnumerable<object[]> FromIntTests_MemberData() =>
            MatrixGenerator(FromIntTests_MemberDataSeed(), false);

        [Theory]
        [MemberData(nameof(FromIntTests_MemberData))]
        public void ToByteArray_FromIntTests_Advanced(int i, bool isUnsigned, bool isBigEndian, byte[] expectedBytes)
        {
            BigInteger bi = new BigInteger(i);

            if (i < 0 && isUnsigned)
            {
                Assert.Throws<OverflowException>(() => bi.ToByteArray(isUnsigned, isBigEndian));
                return;
            }

            byte[] bytes = bi.ToByteArray(isUnsigned, isBigEndian);
            Assert.Equal(expectedBytes, bytes);
            BigInteger bi2 = new BigInteger(bytes, isUnsigned, isBigEndian);
            Assert.Equal(bi, bi2);
        }

        public static IEnumerable<object[]> FromLongTests_MemberData() =>
            MatrixGenerator(FromLongTests_MemberDataSeed(), false);

        [Theory]
        [MemberData(nameof(FromLongTests_MemberData))]
        public void ToByteArray_FromLongTests_Advanced(long l, bool isUnsigned, bool isBigEndian, byte[] expectedBytes)
        {
            BigInteger bi = new BigInteger(l);

            if (l < 0 && isUnsigned)
            {
                Assert.Throws<OverflowException>(() => bi.ToByteArray(isUnsigned, isBigEndian));
                return;
            }

            byte[] bytes = bi.ToByteArray(isUnsigned, isBigEndian);
            Assert.Equal(expectedBytes, bytes);
            BigInteger bi2 = new BigInteger(bytes, isUnsigned, isBigEndian);
            Assert.Equal(bi, bi2);
        }

        public static IEnumerable<object[]> FromStringTests_MemberData() =>
            MatrixGenerator(FromStringTests_MemberDataSeed(), true);

        [Theory]
        [MemberData(nameof(FromStringTests_MemberData))]
        public void ToByteArray_FromStringTests_Advanced(string str, bool isUnsigned, bool isBigEndian, byte[] expectedBytes)
        {
            BigInteger bi = BigInteger.Parse(str);

            if (str[0] == '-' && isUnsigned)
            {
                Assert.Throws<OverflowException>(() => bi.ToByteArray(isUnsigned, isBigEndian));
                return;
            }

            byte[] bytes = bi.ToByteArray(isUnsigned, isBigEndian);
            Assert.Equal(expectedBytes, bytes);
            BigInteger bi2 = new BigInteger(bytes, isUnsigned, isBigEndian);
            Assert.Equal(bi, bi2);
        }

        private static IEnumerable<object[]> MatrixGenerator(IEnumerable<object[]> seedData, bool dataIsBigEndian)
        {
            foreach (object[] seed in seedData)
            {
                object value = seed[0];
                byte[] leSignedBytes = (byte[])seed[1];
                byte[] beSignedBytes = (byte[])leSignedBytes.Clone();
                Array.Reverse(beSignedBytes);

                if (dataIsBigEndian)
                {
                    var tmp = leSignedBytes;
                    leSignedBytes = beSignedBytes;
                    beSignedBytes = tmp;
                }

                // Signed Little Endian
                yield return new object[] { value, false, false, leSignedBytes };

                // Signed Big Endian
                yield return new object[] { value, false, true, beSignedBytes };

                byte[] leUnsignedBytes;
                byte[] beUnsignedBytes;

                if (beSignedBytes.Length > 1 &&
                    beSignedBytes[0] == 0)
                {
                    leUnsignedBytes = new Span<byte>(leSignedBytes, 0, leSignedBytes.Length - 1).ToArray();
                    beUnsignedBytes = new Span<byte>(beSignedBytes, 1, beSignedBytes.Length - 1).ToArray();
                }
                else
                {
                    // No padding was required, the unsigned data is the same as the signed data.
                    leUnsignedBytes = leSignedBytes;
                    beUnsignedBytes = beSignedBytes;
                }

                // Unsigned Big Endian
                yield return new object[] { value, true, true, beUnsignedBytes };

                // Unsigned Little Endian
                yield return new object[] { value, true, false, leUnsignedBytes };
            }
        }
    }
}

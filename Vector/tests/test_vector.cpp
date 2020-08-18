#define CATCH_CONFIG_MAIN // This tells Catch to provide a main() - only do this in one cpp file

#include "catch.hpp"
#include "vector.h"

typedef double Vec3[3];

void cmp_vec_arr(const Vector &lhs, const Vec3 &rhs) {
    assert(Vector::Count == sizeof(rhs)/sizeof(rhs[0]));
    for (unsigned i = 0; i < Vector:: Count; ++i) {
        REQUIRE(lhs[i] == rhs[i]);
    }    
}

TEST_CASE("Vector default ctor") {
    Vector v;
    Vec3 expected = {0.0, 0.0, 0.0};
    cmp_vec_arr(v, expected);
}

TEST_CASE("Vector init value ctor") {
    SECTION("Zeros") {
        Vector v{0};
        Vec3 expected = {0.0, 0.0, 0.0};
        cmp_vec_arr(v, expected);
    }
    SECTION("Ones") {
        Vector v{1.0};
        Vec3 expected = {1.0, 1.0, 1.0};
        cmp_vec_arr(v, expected);
    }
    SECTION("Minus ones") {
        Vector v{-1.0};
        Vec3 expected = {-1.0, -1.0, -1.0};
        cmp_vec_arr(v, expected);
    }
    SECTION("42") {
        Vector v{42};
        Vec3 expected = {42.0, 42.0, 42.0};
        cmp_vec_arr(v, expected);
    }
}

TEST_CASE("Vector copy ctor") {
    SECTION("Zeros") {
        Vector v{0};
        Vector copy{v};
        Vec3 expected = {0.0, 0.0, 0.0};
        cmp_vec_arr(copy, expected);
    }
    SECTION("Ones") {
        Vector v{1.0};
        Vector copy{v};
        Vec3 expected = {1.0, 1.0, 1.0};
        cmp_vec_arr(copy, expected);
    }
    SECTION("Minus ones") {
        Vector v{-1.0};
        Vector copy{v};
        Vec3 expected = {-1.0, -1.0, -1.0};
        cmp_vec_arr(copy, expected);
    }
    SECTION("42") {
        Vector v{42};
        Vector copy{v};
        Vec3 expected = {42.0, 42.0, 42.0};
        cmp_vec_arr(copy, expected);
    }
}

TEST_CASE("Vector copy assignment") {
    SECTION("Zeros") {
        Vector v{0}, copy;
        copy = v;
        Vec3 expected = {0.0, 0.0, 0.0};
        cmp_vec_arr(copy, expected);
    }
    SECTION("Ones") {
        Vector v{1.0}, copy;
        copy = v;
        Vec3 expected = {1.0, 1.0, 1.0};
        cmp_vec_arr(copy, expected);
    }
    SECTION("Minus ones") {
        Vector v{-1.0}, copy;
        copy = v;
        Vec3 expected = {-1.0, -1.0, -1.0};
        cmp_vec_arr(copy, expected);
    }
    SECTION("42") {
        Vector v{42}, copy;
        copy = v;
        Vec3 expected = {42.0, 42.0, 42.0};
        cmp_vec_arr(copy, expected);
    }
}

TEST_CASE("Indexing operator") {
    Vector v;
    Vec3 expected = {1.0, 2.0, 3.0};
    for (unsigned long i = 0; i < Vector::Count; ++i) {
        v[i] = expected[i];
    }
    cmp_vec_arr(v, expected);
}

TEST_CASE("Add operator") {
    Vector v{1}, w{2};
    v += w;
    Vec3 expected = {3.0, 3.0, 3.0};
    cmp_vec_arr(v, expected);
}

TEST_CASE("sub operator") {
    Vector v{1}, w{2};
    v -= w;
    Vec3 expected = {-1.0, -1.0, -1.0};
    cmp_vec_arr(v, expected);
}

TEST_CASE("mul operator") {
    Vector v{1};
    v *= 2.0;
    Vec3 expected = {2.0, 2.0, 2.0};
    cmp_vec_arr(v, expected);
}

TEST_CASE("div operator") {
    Vector v{1};
    v /= 2.0;
    Vec3 expected = {.5, .5, .5};
    cmp_vec_arr(v, expected);
}

TEST_CASE("Plus operator") {
    Vector v{1}, w{2};
    Vector z{v + w};
    Vec3 expected = {3.0, 3.0, 3.0};
    cmp_vec_arr(z, expected);
}

TEST_CASE("Minus operator") {
    Vector v{1}, w{2};
    Vector z{v - w};
    Vec3 expected = {-1.0, -1.0, -1.0};
    cmp_vec_arr(z, expected);
}

TEST_CASE("Multiple operator") {
    SECTION("mul left") {
        Vector v{1};
        Vector z{v * 2.0};
        Vec3 expected = {2.0, 2.0, 2.0};
        cmp_vec_arr(z, expected);
    }
    SECTION("mul right") {
        Vector v{1};
        Vector z{2.0*v};
        Vec3 expected = {2.0, 2.0, 2.0};
        cmp_vec_arr(z, expected);
    }
}

TEST_CASE("Divide operator") {
    Vector v{1};
    Vector z{v / 2.0};
    Vec3 expected = {.5, .5, .5};
    cmp_vec_arr(z, expected);
}

TEST_CASE("Unary minus") {
    Vector v{1};
    Vec3 expected = {-1.0, -1.0, -1.0};
    cmp_vec_arr(-v, expected);
}

TEST_CASE("Equal operator") {
    SECTION("Equal") {
        Vector v{2}, w{2};
        REQUIRE(v == w);
    }
    SECTION("Not equal") {
        Vector v{1}, w{2};
        REQUIRE(v != w);
    }
}

TEST_CASE("Dot product") {
    SECTION("Non zero") {
        Vector v{1}, w{2};
        REQUIRE( 6.0 == (v ^ w));
    }
    SECTION("zero") {
        Vector v, w;
        v[0] = 1.0;
        w[1] = 1.0;
        REQUIRE(0.0 == (v ^ w));
    }
}
#ifndef SOLUTIONS_H
#define SOLUTIONS_H

#include <cmath>

inline double solutionPlus(int a, int b, int delta)
{
    b *= -1;
    double x { b + std::sqrt(delta) };
    
    return x / (2 * a);
}

inline double solutionMinus(int a, int b, int delta)
{
    b *= -1;
    double x { b - std::sqrt(delta) };
    
    return x / (2 * a);
}

#endif
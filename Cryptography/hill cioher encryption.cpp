#include <iostream>
#include <vector>
using namespace std;

int mod(int a, int m) {
    return (a % m + m) % m;
}

int gcdExtended(int a, int b, int &x, int &y) {
    if (a == 0) {
        x = 0;
        y = 1;
        return b;
    }
    int x1, y1;
    int gcd = gcdExtended(b % a, a, x1, y1);
    x = y1 - (b / a) * x1;
    y = x1;
    return gcd;
}

int modInverse(int a, int m) {
    int x, y;
    int g = gcdExtended(a, m, x, y);
    if (g != 1) {
        return -1; // Inverse doesn't exist
    } else {
        return mod(x, m);
    }
}

void getCofactor(const vector<vector<int>> &a, vector<vector<int>> &temp, int p, int q, int n) {
    int i = 0, j = 0;
    for (int row = 0; row < n; row++) {
        for (int col = 0; col < n; col++) {
            if (row != p && col != q) {
                temp[i][j++] = a[row][col];
                if (j == n - 1) {
                    j = 0;
                    i++;
                }
            }
        }
    }
}

int determinant(const vector<vector<int>> &a, int n) {
    if (n == 1)
        return a[0][0];
    int det = 0;
    vector<vector<int>> temp(n, vector<int>(n));
    int sign = 1;
    for (int f = 0; f < n; f++) {
        getCofactor(a, temp, 0, f, n);
        det += sign * a[0][f] * determinant(temp, n - 1);
        sign = -sign;
    }
    return det;
}

void adjoint(const vector<vector<int>> &a, vector<vector<int>> &adj) {
    int n = a.size();
    if (n == 1) {
        adj[0][0] = 1;
        return;
    }
    int sign = 1;
    vector<vector<int>> temp(n, vector<int>(n));
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            getCofactor(a, temp, i, j, n);
            sign = ((i + j) % 2 == 0) ? 1 : -1;
            adj[j][i] = sign * determinant(temp, n - 1);
        }
    }
}

bool inverse(const vector<vector<int>> &a, vector<vector<int>> &inv) {
    int n = a.size();
    int det = determinant(a, n);
    int invDet = modInverse(det, 26);
    if (invDet == -1) {
        cout << "Inverse does not exist";
        return false;
    }
    vector<vector<int>> adj(n, vector<int>(n));
    adjoint(a, adj);
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n;


#include <iostream>
#include <cmath>

using namespace std;

// Function to compute modular exponentiation (base^exp % mod)
long long modExp(long long base, long long exp, long long mod) {
    long long result = 1;
    base = base % mod;
    while (exp > 0) {
        if (exp % 2 == 1) { // If exp is odd
            result = (result * base) % mod;
        }
        exp = exp >> 1; // Divide exp by 2
        base = (base * base) % mod;
    }
    return result;
}

// Generate the signature
pair<long long, long long> signMessage(const string &message, long long privateKey, long long P, long long Q, long long G) {
    // Simple hash function for demonstration (not secure for real use)
    long long H = 0;
    for (char c : message) {
        H = (H * 31 + c) % Q;
    }

    // Generate random k
    long long k = rand() % (Q - 1) + 1;

    // Compute r and s
    long long r = modExp(G, k, P) % Q;
    long long k_inv = modExp(k, Q - 2, Q); // Modular inverse of k
    long long s = (k_inv * (H + privateKey * r)) % Q;

    return {r, s};
}

// Verify the signature
bool verifySignature(const string &message, long long r, long long s, long long publicKey, long long P, long long Q, long long G) {
    // Hash the message
    long long H = 0;
    for (char c : message) {
        H = (H * 31 + c) % Q;
    }

    // Compute v1 and v2
    long long w = modExp(s, Q - 2, Q); // Modular inverse of s
    long long u1 = (H * w) % Q;
    long long u2 = (r * w) % Q;

    long long v1 = modExp(G, u1, P);
    long long v2 = modExp(publicKey, u2, P);
    v2 = (v1 * v2) % P;
    v1 = v2 % Q;

    return v1 == r;
}

int main() {
    long long P, Q, G, X;

    // Input P, Q, G, and private key X
    cout << "Enter a large prime number P: ";
    cin >> P;
    cout << "Enter a large prime number Q (Q < P): ";
    cin >> Q;
    cout << "Enter a base G: ";
    cin >> G;
    cout << "Enter the private key X: ";
    cin >> X;

    // Generate public key Y
    long long Y = modExp(G, X, P);

    string message;
    cout << "Enter a message to sign: ";
    cin.ignore(); // Ignore the newline character from previous input
    getline(cin, message);

    // Sign the message
    auto [r, s] = signMessage(message, X, P, Q, G);
    cout << "Signature (r, s): " << r << ", " << s << endl;

    // Verify the signature
    bool isValid = verifySignature(message, r, s, Y, P, Q, G);
    cout << (isValid ? "Signature verification succeeded.\n" : "Signature verification failed.\n");

    return 0;
}

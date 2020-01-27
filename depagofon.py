import os
import base64
from binascii import hexlify

from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes
from cryptography.hazmat.primitives import hashes, hmac
from cryptography.hazmat.backends import default_backend


backend = default_backend()
# Llave falsa
key = key = b"vcOqXPg==lz3M0IH4swwYCR/"[:16]


def decrypt(message):
    message = base64.urlsafe_b64decode(message)
    iv = message[:16]
    signed_data = message[16:36]
    encrypted_data = message[36:]
    cipher = Cipher(algorithms.AES(key), modes.CBC(iv), backend=backend)
    print(f"iv {len(iv)} {hexlify(iv).decode('ascii')}")
    print(f"signed {len(signed_data)} {signed_data}")
    print(
        f"encrypted_data {len(encrypted_data)} {hexlify(encrypted_data).decode('ascii')}"
    )
    decryptor = cipher.decryptor()
    plaintext_message = decryptor.update(encrypted_data) + decryptor.finalize()
    # Remove null padding if it exists
    plaintext_message = plaintext_message.split(b"\x00")[0]
    print("result")
    print(hexlify(plaintext_message).decode("ascii"))
    try:
        plaintext_message = plaintext_message.decode("utf-8")
    except:
        print("could not decode")
    return plaintext_message


print(
    decrypt(
        "JW8iuMPmRApsR43iR//gxUdukchHGWhMm4hyummPuI9IT4xuRxh74uP2j6QPgcZYy1lzfBDEHlTFYHMLwII+Ye5t4hLdfuyMWMle8SHFdtWMei/6y8O8dXU6oCjUM2T1vOeb/XoyoAh9sAsYCdkDdo8DrfBtVGSVutz36RopgJL3NilDgTf6FPn7cBYetLPrago5fMuCG6ygr5iMVMkBDMAX7nzL/Z6NGIbbbpBPNyYIi3LbttjoQIeyRfI4lOg2b1fUnw=="
    )
)


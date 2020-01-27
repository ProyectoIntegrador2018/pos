import os
import base64
import binascii

from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes
from cryptography.hazmat.primitives import hashes, hmac
from cryptography.hazmat.backends import default_backend

backend = default_backend()
# Llave falsa
key = b"vcOqXPg==lz3M0IH4swwYCR/"[:16]
iv = os.urandom(16)


def encrypt(message):
    print("iv hex", binascii.hexlify(iv).decode("ascii"))
    cipher = Cipher(algorithms.AES(key), modes.CBC(iv), backend=backend)
    encryptor = cipher.encryptor()

    message = bytes(message, encoding="utf-8")
    pad_len = 16 - (len(message) % 16)
    message = bytes(bytearray(message) + bytearray(pad_len))
    data = encryptor.update(message) + encryptor.finalize()
    hash_key = os.urandom(256)
    h = hmac.HMAC(hash_key, hashes.SHA256(), backend=backend)
    h.update(data)
    signature = h.finalize()[20:]
    # Optional padding if necessary
    signature = bytes(bytearray(signature) + bytearray(20 - (len(signature) % 20)))
    payload = iv + signature + data
    print(f"iv {len(iv)} {iv}")
    print(f"hmac {len(signature)} {signature}")
    print(f"data {len(data)} {data}")
    print(f"payload {payload}")
    result = base64.urlsafe_b64encode(payload)
    return result


print(
    encrypt(
        '{"ActivationCode":"1169325819","SystemModuleID":"","ProductServiceType":"0","RequestUniqueID":"12","MethodName":"GetProductDetails","RequestIP":"127.0.0.1"}'
    )
)

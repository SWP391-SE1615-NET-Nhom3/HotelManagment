


function toggleKeyOn(id) {
    const apiUrl = 'https://localhost:7156/api/Account/ActionAccount';
    const data = {
        account_id: id,
        status: 1,
    };
    console.log(data);
    fetch(apiUrl, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(response => {
            if (!response.ok) {
                return response.json().then(errorData => {
                    alert(errorData)
                 });
            }
           
        })
        .then(responseData => {
            console.log('API PUT thành công:', responseData);
            window.location.reload();
        })
        .catch(error => {
            console.error('Có lỗi khi gọi API PUT:', error);
            // Xử lý lỗi nếu cần
        });
}
function toggleKeyOff(id) {
    const apiUrl = 'https://localhost:7156/api/Account/ActionAccount';
    const data = {
        account_id: id,
        status: 0,
    };
    
    console.log(data);
    fetch(apiUrl, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(response => {
            if (!response.ok) {
                return response.json().then(errorData => {
                    alert(errorData)
                 });
            }
           
        })
        .then(responseData => {
            console.log('API PUT thành công:', responseData);
            window.location.reload();
        })
        .catch(error => {
            console.error('Có lỗi khi gọi API PUT:', error);
            // Xử lý lỗi nếu cần
        });
}
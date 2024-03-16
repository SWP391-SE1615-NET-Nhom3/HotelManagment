

function getAndPopulateData() {
    // Tạo một yêu cầu GET đến API
    fetch('https://localhost:7156/api/Account/teacher%40gmail.com',{
        headers: {
            'Authorization': `Bearer ${token}`, 
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (!response.ok) {
                return response.json().then(errorData => {
                    alert(errorData)
                 });
            }
            return response.json();
        })
        .then(data => {
            const nameInput = document.getElementById('name');
            const emailInput = document.getElementById('email');
            const passwordInput = document.getElementById('password');
            const addressInput = document.getElementById('address');
            const phoneInput = document.getElementById('phone');
            const roleRadioInputs = document.getElementsByName('gridRadios');
          
            // Điền giá trị vào các trường input từ dữ liệu nhận được từ API
            nameInput.value = data.name;
            emailInput.value = data.email;
            passwordInput.value = data.password;
            addressInput.value = data.address;
            phoneInput.value = data.phone;
            for (const radioButton of roleRadioInputs) {
                if (radioButton.value === data.radioButtons) {
                    radioButton.checked = true;
                    break;
                }
            }
          
        })
        .catch(error => {
            console.error('Error fetching API:', error);
        });
}

// Gọi hàm khi trang được tải
document.addEventListener('DOMContentLoaded', getAndPopulateData);

$(document).ready(function() {

	$('.open-form').click(function() {
		$('.form-popup').show();
	});
	$('.close-form').click(function() {
		$('.form-popup').hide();
	});
  
	$('.reset-form').click(function() {
		$('.success-message').show();
    $('#my-form').trigger( 'reset' );

    setTimeout(function() {
	    $('.success-message').hide()
    }, 1500);
	});

	$(document).mouseup(function(e) {
		var container = $(".form-wrapper");
		var form = $(".form-popup");

		if (!container.is(e.target) && container.has(e.target).length === 0) {
			form.hide();
		}
	});


});
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//allow db connection
using COMP2007_S2016_MidTerm_200284512.Models;
using System.Web.ModelBinding; 
using System.Linq.Dynamic; 


/**
 * Author: Josh Mangoff
 * Student #: 200284512
 * Date Modified: June 23, 2016
 * Version: 0.0.3 - has grid view deleting
 * Description: Unmodified .cs file of TodoList page
 */

namespace COMP2007_S2016_MidTerm_200284512
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //when loading page, load grid
            if (!IsPostBack)
            {
                this.GetTodos();
            }
        }

        /**
         * <summary>
         * Gets data from database
         * </summary>
         * @method GetTodos
         * @returns {void}
         */
        protected void GetTodos()
        {
            //connect to db
            using (TodoConnection db = new TodoConnection())
            {
                //load from db
                var Todos = (from allTodos in db.Todos select allTodos);

                //update grid
                TodoGridView.DataSource = Todos.AsQueryable().ToList();
                TodoGridView.DataBind();
            }
        }

        /**
         * <summary>
         * Deletes data from database
         * </summary>
         * @method TodoGridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs} e
         * @returns {void}
         */
        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store row
            int selectedRow = e.RowIndex;

            //get id
            int TodoID = Convert.ToInt32(TodoGridView.DataKeys[selectedRow].Values["TodoID"]);

            //connect to db
            using (TodoConnection db = new TodoConnection())
            {
                //find todo
                Todo deletedTodo = (from todoRecords in db.Todos 
                                          where todoRecords.TodoID == TodoID 
                                          select todoRecords).FirstOrDefault(); 
                //delete todo
                db.Todos.Remove(deletedTodo);

                //save db
                db.SaveChanges();

                //update grid
                this.GetTodos();
            }

        }

    }
}